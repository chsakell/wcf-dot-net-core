using System.Runtime.Serialization;

namespace Business.Entities
{
    [DataContract]
    public class Article : IExtensibleDataObject
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Contents { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public int BlogID { get; set; }

        [DataMember]
        public int ContentLength
        {
            get
            {
                return Contents.Length;
            }
            set { }
        }

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}
