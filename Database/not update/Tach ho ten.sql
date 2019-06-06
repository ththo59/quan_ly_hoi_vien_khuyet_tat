update QL_HOIVIEN set  HV_HO = SUBSTRING(HV_HO, 1, LEN(HV_HO) - CHARINDEX(' ', reverse(HV_HO))),
HV_TEN =  SUBSTRING(HV_HO,
                 LEN(HV_HO) - CHARINDEX(' ', reverse(HV_HO)) + 2,
                 LEN(HV_HO) - CHARINDEX(' ', reverse(HV_HO)))