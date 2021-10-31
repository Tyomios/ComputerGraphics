using System;

namespace Model
{
	/// <summary>
	/// Матрица.
	/// </summary>
	public class Matrix
	{
		/// <summary>
		/// Максимальный размер матрицы.
		/// </summary>
		private const int _maxSize = 4;

		/// <summary>
		/// Значение матрицы.
		/// </summary>
		private double[,] _matrixValues = new double[_maxSize, _maxSize];

		/// <summary>
		/// Возвращает или задает значение матрицы.
		/// </summary>
		public double[,] MatrixValues
		{
			get => _matrixValues;
			set
			{
				if (value.Length > 4)
				{
					throw new Exception("Max matrix length - 4");
				}
				_matrixValues = value;
			}

		}

		/// <summary>
		/// Создает экземпляр <see cref="Matrix"/>
		/// </summary>
		/// <param name="values"> Значения матрицы. </param>
		public Matrix(double[,] values)
		{
			MatrixValues = values;
		}

		public Matrix()
		{

		}

		/// <summary>
		/// Произведение матрицы на матрицу.
		/// </summary>
		/// <param name="secondMatrix"> Вторая матрица </param>
		/// <returns> Матрицу произведения двух матриц </returns>
		public Matrix MultiplyMatrix(Matrix secondMatrix)
		{
			Matrix resultMatrix = new Matrix();

			for (int i = 0; i < MatrixValues.Length; i++)
			{
				for (int j = 0; j < secondMatrix.MatrixValues.Length; j++)
				{
					
					for (int k = 0; k < MatrixValues.Length; k++)
					{
						resultMatrix.MatrixValues[j, i] += MatrixValues[k, i] * secondMatrix.MatrixValues[j, k];
					}
				}
			}

			return resultMatrix;
		}

		public Matrix AddictionMatrix(Matrix secondMatrix)
		{
			var resultMatrix = new Matrix();
			return resultMatrix;
		}

		public Matrix SubtractMatrix(Matrix secondMatrix)
		{
			var resultMatrix = new Matrix();
			return resultMatrix;
		}
	}
}
