using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnJobEntity
{
    public class SystemEnum
    {

    }

    public enum Degree_Level
    {

    
        Bachelor_degree = 1,
        Diploma = 2,
        Doctorate = 3,
        Higher_diploma = 4,
        High_school_or_equivalent = 4,

        [Description("Master's degree")]
        Masters_degree = 5,



    }
}
