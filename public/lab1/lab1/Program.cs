using System;
using System.Threading;

namespace lab1 {
	static class Program {
		const int Length = 3;

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

		private static int[] Mult(int[,] matrix, int[] vec,int length) {
			int[] res = new int[length];
			for (int i = 0; i < length; i++) {
				for (int j = 0; j < length; j++) {
					res[i] += matrix[i,j] * vec[j];
				}
			}
			return res;
		}
		
		
		
		private static void Multiplication(int tmp) {
			
			int core = step_i++; 

			// Each thread computes 1/4th of matrix multiplication 
			for (int i = core * MAX / 4; i < (core + 1) * MAX / 4; i++) 
			for (int j = 0; j < MAX; j++) 
			for (int k = 0; k < MAX; k++) 
				matC[i][j] += matA[i][k] * matB[k][j]; 
			
			
			
		}
		
		
		
		
		static void Main(string[] args) {
			const int maxThread = 4;
			
			int[,] matrix = GetMatrix(Length);
			int[] vector = GetVector(Length);

			Console.Write("Matrix: \n");
			for (int i = 0; i < Length; i++){
				for (int j = 0; j < Length; j++){
					Console.Write("{0}\t", matrix[i, j]);
				}
				Console.WriteLine();
			}
			Console.Write("\nVector: \n");
			foreach (var number in vector){
				Console.Write("{0}\t", number);
			}
			
			
			
			
			int[] res = Mult(matrix, vector, Length);
			
			
			
			Thread[] threads = new Thread[4];
			
			for (int i = 0; i < 4; i++){
				int localNum = i;
				threads[i] = new Thread(() => Multiplication(localNum));
			}
			for (int i = 0; i < 4; i++){
				threads[i].Start();
			}
			for (int i = 0; i < 4; i++){
				threads[i].Join();
			}







			Console.Write("\nResult: \n");
			foreach (var number in res){
				Console.Write("{0}\t", number);
			}
		}
	}
}