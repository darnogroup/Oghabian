using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domin.Enum;

namespace Application.Other
{
    public static class ConvertEnum
    {
        public static ConditionEnumViewModel ConditionToViewModel(ConditionEnum condition)
        {
           
            switch (condition)
            {
                case ConditionEnum.Open:
                    return ConditionEnumViewModel.Open;
                case ConditionEnum.Delivery:
                    return ConditionEnumViewModel.Delive;
                case ConditionEnum.Preparation:
                    return ConditionEnumViewModel.Preparation;
                case ConditionEnum.Record:
                    return ConditionEnumViewModel.Record;
                default: return ConditionEnumViewModel.Open;
            }
        }

        public static ConditionEnum ConditionToModel(ConditionEnumViewModel condition)
        {
            switch (condition)
            {
                case ConditionEnumViewModel.Open:
                    return ConditionEnum.Open;

                case ConditionEnumViewModel.Delive:
                    return ConditionEnum.Delivery;

                case ConditionEnumViewModel.Preparation:
                    return ConditionEnum.Preparation;

                case ConditionEnumViewModel.Record:
                    return ConditionEnum.Record;
                default:
                    return ConditionEnum.Open;
            }
        }

        public static GenderEnumViewModel ChangeGenderToViewModel(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return GenderEnumViewModel.مذکر;
                case Gender.Female:
                    return GenderEnumViewModel.مونث;
                default:
                    return GenderEnumViewModel.مذکر;
            }
        }

        public static Gender ChangeGenderToModel(GenderEnumViewModel gender)
        {
            switch (gender)
            {
                case GenderEnumViewModel.مذکر:
                    return Gender.Male;
                case GenderEnumViewModel.مونث:
                    return Gender.Female;
                default:
                    return Gender.Male;
            }
        }
    }
}
