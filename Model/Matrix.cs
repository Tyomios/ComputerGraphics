﻿using System;
using System.Collections.Generic;

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

		public int Size { get; set; }

		/// <summary>
		/// Создает экземпляр <see cref="Matrix"/>
		/// </summary>
		/// <param name="values"> Значения матрицы. </param>
		public Matrix(double[,] values)
		{
			MatrixValues = values;
		}

		public Matrix(int size)
		{
			_matrixValues = new double[size, size];
			Size = size;
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

			for (int i = 0; i < Size; i++) // строка
			{
				for (int j = 0; j < secondMatrix.Size; j++) // столбец
				{
					for (int k = 0; k < secondMatrix.Size; k++)
					{
						resultMatrix.MatrixValues[i, j] += MatrixValues[i, k] * secondMatrix.MatrixValues[k, j];
					}
					
				}
			}

			return resultMatrix;
		}

		public Matrix MultiplyConst()
		{
			var resultMatrix = new Matrix(Size);
			const int k = 6;
			for (var i = 0; i < Size; i++)
			{
				for (var j = 0; j < Size; j++)
				{
					resultMatrix.MatrixValues[i, j] = MatrixValues[i, j] * k;
				}
			}

			return resultMatrix;
		}

		public Matrix MultiplyVector(List<double> vector)
		{
			var resultMatrix = new Matrix(Size);
			

			for (var i = 0; i < Size; i++)
			{
				for (var j = 0; j < Size; j++)
				{
					resultMatrix.MatrixValues[i, 0] += MatrixValues[i, j] * vector[j];
				}
			}

			return resultMatrix;
		}

		public Matrix AddictionMatrix(Matrix secondMatrix)
		{
			Matrix resultMatrix = new Matrix();

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < secondMatrix.Size; j++)
				{

					resultMatrix.MatrixValues[i, j] += MatrixValues[i, j] + secondMatrix.MatrixValues[i, j];
				}
			}

			return resultMatrix;
		}

		public Matrix SubtractMatrix(Matrix secondMatrix)
		{
			Matrix resultMatrix = new Matrix();

			for (int i = 0; i < Size; i++)
			{
				for (int j = 0; j < secondMatrix.Size; j++)
				{

					resultMatrix.MatrixValues[i, j] += MatrixValues[i, j] - secondMatrix.MatrixValues[i, j];
				}
			}

			return resultMatrix;
		}
	}
}
