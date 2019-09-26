using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Server.Data;

namespace Server.Repositories
{
    public class TextRepository : ITextRepository
    {
        private TextContext _context;

        public TextRepository(TextContext context)
        {
            _context = context;
        }

        public TextData GetText()
        {
            return _context.TextDataTable.FirstOrDefault();
        }
    }
}
