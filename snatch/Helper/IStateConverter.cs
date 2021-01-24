using System;
using System.Collections.Generic;
using System.Text;

namespace snatch.Helper
{

    interface IStateConverter
    {
        public string To<T>(T toConvert);

        public T From<T>(string fromConvert);
    }
}
