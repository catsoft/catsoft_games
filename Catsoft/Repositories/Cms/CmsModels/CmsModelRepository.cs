﻿using App.cms.Repositories.CmsModels;
using App.Models;

namespace App.Repositories.Cms.CmsModels
{
    public class CmsModelRepository(CatsoftContext catsoftContext) : CmsCmsModelRepository<CatsoftContext>(
        catsoftContext);
}