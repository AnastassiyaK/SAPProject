﻿namespace SAPBusiness.Tutorial.Step
{
    using System;

    public class AccordionTable : AccordionComponent, IAccordion
    {
        // private static string textColunm = "Content in the column";
        // private static string textRow = "Content in the row";
        // private readonly int _rows;
        // private readonly int _colums;
        // public AccordionTable(int rows, int colums)
        // {
        //    _rows = rows;
        //    _colums = colums;
        // }
        public void AddComponent(AccordionComponent component)
        {
        }

        public override string FormatView()
        {
            throw new NotImplementedException();
        }
    }
}
