﻿using System;
using System.Linq;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Common.Dto;

namespace WebSite.Application.Services.Rules.Commands.DeleteRule
{
    public class DeleteRuleService : IDeleteRuleService
    {
        private readonly IDataBaseContext dataBaseContext;

        public DeleteRuleService(IDataBaseContext dataBaseContext) =>
            this.dataBaseContext = dataBaseContext;

        public ResultDto Execute(DeleteRuleRequest request)
        {
            var rule = dataBaseContext.Rules.FirstOrDefault(x => x.Id == request.Id && x.Owner == request.Owner);

            if (rule == null)
            {
                return new ResultDto(false, "Rule is not available.");
            }

            rule.IsDeleted = true;
            rule.DeleteTime = DateTime.Now;

            dataBaseContext.SaveChanges();

            return new ResultDto(true, "قاعده با موفقیت حذف شد.");
        }
    }
}
