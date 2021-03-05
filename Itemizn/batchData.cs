using System;
using System.Collections;

namespace gemoDream
{
	/// <summary>
	/// Summary description for batchData.
	/// </summary>
	public class BatchItem
	{
		public ArrayList Items = new ArrayList();
		public string lotNumber;
		public int weight;
		public string weightUnit;
		public int number;
		public BatchItem(int number)
		{
			this.number = number;
		}
	};
	public class Batch
	{
		public ArrayList Items = new ArrayList();
		public string itemName;
		public int number;
		public int weight;
		public Batch(int number)
		{
			this.number = number;
		}
	};
	public class EntryBatch
	{
		public string scanNumber;
		public int itemsCountInspected;
		public int itemsCount = 0;
		public ArrayList Batches = new ArrayList();
		public EntryBatch()
		{
		}
	};
}
