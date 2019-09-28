using System;
using System.Collections.Generic;
using System.Text;
using Server.Models;
using Server.Repositories;

namespace Server.Test.FakeRepositories
{
    class FakeTextRepository : ITextRepository
    {
        public TextData GetText()
        {
            return new TextData()
            {
                Id = 10,
                Text = "This is text from fake text repository"
            };
        }
    }
}
