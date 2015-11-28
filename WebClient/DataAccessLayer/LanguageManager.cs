using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LanguageManager
    { 
        
        OrderEntities entity;
       public LanguageManager()
        {
            entity = new OrderEntities();
        }

        public ICollection<Language> GetLanguage()
        {
            return entity.Languages.ToList();
        }

        public Language GetLanguageByCultureName(string cultureName)
        {
            return entity.Languages.FirstOrDefault(r => r.CultureName == cultureName);
        }

    }
}

