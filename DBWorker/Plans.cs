//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBWorker
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plans
    {
        public int idTeacher { get; set; }
        public int idPupil { get; set; }
        public System.DateTime date { get; set; }
        public string plan { get; set; }
        public string comment { get; set; }
    }
}