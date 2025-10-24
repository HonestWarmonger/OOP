using System.Collections.Generic;
using DAL.Data;
using DAL.Entities;

namespace DAL
{
    public class EntityContext
    {
        private readonly IDataProvider<MyString> _provider;
        public EntityContext(IDataProvider<MyString> provider) => _provider = provider;

        public void Save(string path, IEnumerable<MyString> data) => _provider.Serialize(path, data);
        public List<MyString> Load(string path) => _provider.Deserialize(path);
        public string Ext => _provider.FileExtension;
    }
}

