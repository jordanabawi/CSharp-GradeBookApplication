using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook: BaseGradeBook
    {

        StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }

        
    }
}
