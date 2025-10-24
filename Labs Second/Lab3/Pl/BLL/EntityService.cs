using System.Collections.Generic;
using System.Linq;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class EntityService
    {
        private readonly EntityContext _ctx;
        public EntityService(EntityContext ctx) => _ctx = ctx;

        public void Save(string path, IEnumerable<MyString> arr) => _ctx.Save(path, arr);
        public List<MyString> Load(string path) => _ctx.Load(path);

        public List<MyString> ReplaceAll(IEnumerable<MyString> list, string oldSub, string newSub)
        {
            var result = list.ToList();
            foreach (var s in result)
                s.ReplaceSubstring(oldSub, newSub);
            return result;
        }

        public List<MyString> InsertAll(IEnumerable<MyString> list, int pos, string sub)
        {
            var result = list.ToList();
            foreach (var s in result)
                s.InsertSubstring(pos, sub);
            return result;
        }
    }
}

