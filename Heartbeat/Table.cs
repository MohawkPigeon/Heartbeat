using System;
using System.Collections.Generic;

public class Table
{
	List<List<float>> table = new List<List<float>>();
	// x is horizontal and y is vertical. You can also ignore this and pretend otherwise.
	// Either way, is is first level and y is second level.
	public Table(List<List<float>> cpy = default)
	{
		this.table = cpy;
	}

	public int Copy(List<List<float>> cpy)
	{
		this.table = cpy;
		return 0;
	}

	public int SetCell(int x, int y, float val)
	{
		if (x <= table.Count && y <= table[x].Count)
		{
			table[x][y] = val;
		}
		else
		{
			return 1;
		}
		return 0;
	}

	public int SetColumn(int x, List<float> col)
	{
		if (x <= table.Count && col.Count == table[x].Count)
		{
			table[x] = col;
		}
		else
		{
			return 1;
		}
		return 0;
	}

	public int SetRow(int y, List<float> row)
	{
		if (row.Count < table.Count)
		{
			for (int i = 0; i < row.Count; i++)
			{
				table[i][y] = row[i];
			}
		}
		else
		{
			return 1;
		}
		return 0;
	}

	public float GetCell(int x, int y)
	{
		return table[x][y];
	}

	public List<float> getColumn(int x)
	{
		if (x < table.Count)
		{
			return this.table[x];
		}
		else
		{
			throw new IndexOutOfRangeException();
		}
	}

	public int removeColumn(int x)
	{
		if (x < table.Count && x >= 0)
		{
			this.table[x].RemoveAt(x);
			return 0;
		}
		else
		{
			throw new IndexOutOfRangeException();
		}
		return 1;
	}

	public List<float> getRow(int y)
	{
		List<float> row = new List<float>();
		if (y < table[0].Count && y >= 0)
		{
			for (int i = 0; i < row.Count; i++)
			{
				row[i] = table[i][y];
			}
		}
		else
		{
			throw new IndexOutOfRangeException();
		}
		return row;
	}

	public float sumColumn(int x)
	{
		if (x < 0 || x > this.table[x].Count)
		{
			throw new IndexOutOfRangeException();
		}
		List<float> col = getColumn(x);
		float acc = 0;
		foreach (float cell in col)
		{
			acc += cell;
		}
		return acc;
	}

	public float sumList(List<float> col)
	{
		if (col.Count < 1)
		{
			throw new Exception("List size is less than 1.\n");
		}
		float acc = 0;
		foreach (float cell in col)
		{
			acc += cell;
		}
		return acc;
	}

	public float squareList(List<float> col)
	{
		if (col.Count < 1)
		{
			throw new Exception("List size is less than 1.\n");
		}
		float acc = 0;
		foreach (float cell in col)
		{
			acc += cell * cell;
		}
		return acc;
	}

	public float timesLists(List<float> col, List<float> col2)
	{
		if (col.Count != col2.Count)
		{
			throw new Exception("List size does not match.\n");
		}
		else if (col.Count < 1 || col2.Count < 1)
		{
			throw new Exception("List size is less than 1.\n");
		}
		float acc = 0;
		for (int i = 0; i < col.Count; i++)
		{
			acc += col[i] * col2[i];
		}
		return acc;
	}

	public float residuals(List<float> col, List<float> col2, float a, float b)
	{
		if (col.Count != col2.Count)
		{
			throw new Exception("List size does not match.\n");
		}
		else if (col.Count < 1 || col2.Count < 1)
		{
			throw new Exception("List size is less than 1.\n");
		}
		float acc = 0;
		for (int i = 0; i < col.Count; i++)
		{
			acc += col2[i] - a - b * col[i];
		}
		return acc;
	}

	public (float a, float b, float r, float rss) LinearRegression(List<float> feature, List<float> target)
	{
		int columnSize = feature.Count;
		float x = sumList(feature);
		float y = sumList(target);
		float x2 = squareList(feature);
		float y2 = squareList(target);
		float xy = timesLists(feature, target);
		float b = (columnSize * xy - (x * y)) / (columnSize * x2 - x * x);

		float a = (1f / columnSize) * y - b * (1f / columnSize) * x;
		Console.WriteLine("elo" + x + ".." + y + ".." + x2 + ".." + y2 + ".." + xy + "\n");
		float r = (columnSize * xy - x * y) / (float)Math.Sqrt((columnSize * x2 - x * x) * (columnSize * y2 - y * y));
		float rss = y2 * (1 - r * r);
		return (a, b, r, rss);
	}

	public List<(float a, float r)> EstimateTableFeatureWeight(List<float> target)
	{
		List<(float, float)> weightList = new List<(float, float)>();
		foreach (List<float> col in table)
		{
			var values = LinearRegression(col, target);
			(float, float) ret = (values.b, values.r);
			weightList.Add(ret); //b is the factor for x relevance to y, and r is the cohesion of the data.
		}
		return weightList; //returns a list of estimated weights based on the contribution to the target and the expected accuracy of future contributions (r).
	}
	public List<(float, float)> EstimateTableFeatureWeight(int target)
	{
		Table operationTable = new Table(this.table);
		List<float> targetCol = operationTable.getColumn(target);
		int success = operationTable.removeColumn(target);
		if (success != 0)
		{
			throw new Exception("Column list could not be removed from table.\n");
		}
		return operationTable.EstimateTableFeatureWeight(targetCol);
	}


}