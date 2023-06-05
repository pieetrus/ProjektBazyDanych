using System.Runtime.Serialization;

namespace ProjektyBazyDanych.ViewModels
{
	[DataContract]
	public class DataPoint
	{
		//Explicitly setting the name to be used while serializing to JSON. 
		[DataMember(Name = "label")]
		public string Label = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		public DataPoint(double y, string label)
		{
			this.Y = y;
			this.Label = label;
		}
	}
}
