using System;
using System.Collections.Generic;

namespace SAPBusiness.Tutorial.Step
{
    public class AccordionList : AccordionComponent
    {
        private List<string> _list;

        public AccordionList(List<string> list)
        {
            _list = list;
        }

        public override string FormatView()
        {
            throw new NotImplementedException();
        }
    }
}
