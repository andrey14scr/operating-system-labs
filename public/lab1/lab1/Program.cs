using System;
using System.Threading;

namespace lab1 {
	static class Program {
		const int Length = 2;
		 private static int[,] _matrix;
		 private static int[] _vector;
		 private static int[] _result;
		  const int ThreadsCount = 2;
		private static int step = 0;
		private static int[] GetVector(int length) {
			Random rnd = new Random();
			int[] arr = new int[length];

			for (int i = 0; i < length; i++) {
				arr[i] = rnd.Next(1,10);
			}
			return arr;
		}

		private static int[,] GetMatrix(int length) {
			Random rnd = new Random();
			int[,] matrix = new int[length,length];
			for (int i = 0; i < length; i++) {
				for (int j = 0; j < length; j++) {
					matrix[i, j] = rnd.Next(1,10);
				}
			}
			return matrix;
		}
		private static void Multiplication() {
			int core = step++;
			for (int i = core * Length / ThreadsCount; i < (core + 1) * Length / ThreadsCount; i++) 
				for (int j = 0; j < Length; j++)
					_result[i] += _matrix[i,j] * _vector[j];
		}
		
		static void Main(string[] args) {
			_matrix = new int[Length, Length];
			_vector= new int[Length];
			_result= new int[Length];
			 _matrix = GetMatrix(Length);
			_vector = GetVector(Length);

			Console.Write("Matrix: \n");
			for (int i = 0; i < Length; i++){
				for (int j = 0; j < Length; j++){
					Console.Write("{0}\t", _matrix[i, j]);
				}
				Console.WriteLine();
			}
			Console.Write("\nVector: \n");
			foreach (var number in _vector){
				Console.Write("{0}\t", number);
			}

			Thread[] threads = new Thread[ThreadsCount];
			for (int i = 0; i < ThreadsCount; i++){
				threads[i] = new Thread(Multiplication);
			}
			for (int i = 0; i < ThreadsCount; i++){
				threads[i].Start();
			}
			for (int i = 0; i < ThreadsCount; i++){
				threads[i].Join();
			}
			Console.Write("\nResult: \n");
			foreach (var number in _result){
				Console.Write("{0}\t", number);
			}
		}
	}
}