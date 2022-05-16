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
