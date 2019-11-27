﻿SELECT U.USER_INT_ID, F.FAC_INT_ID, C.CUR_INT_ID, M.MAT_INT_ID
FROM TB_USER AS U
JOIN TB_FACULDADE AS F ON U.USER_INT_ID = F.USER_INT_ID
JOIN TB_CURSO AS C ON U.USER_INT_ID = C.USER_INT_ID
JOIN TB_MATERIA AS M ON U.USER_INT_ID = M.USER_INT_ID
WHERE U.USER_STR_EMAIL = 'odasflavio@hotmail.com';