﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSky.Web.Http.Logging
{
    public interface ILoggingRepository
    {
        void Log(ApiLoggingInfo loggingInfo);
    }
}
