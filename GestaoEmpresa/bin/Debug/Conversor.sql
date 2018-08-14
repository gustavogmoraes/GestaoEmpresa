-- Vai pra produção
ALTER TABLE PRODUTOS
ALTER COLUMN QUANTIDADEESTOQUE INT NULL;
ALTER TABLE PRODUTOS
ADD CONSTRAINT [PK_CODIGO_VIGENCIA] PRIMARY KEY NONCLUSTERED (CODIGO, VIGENCIA);

ALTER TABLE INTERACOES
ADD CONSTRAINT [PK_CODIGO] PRIMARY KEY NONCLUSTERED (CODIGO);

WITH CTE AS(
   SELECT NUMERO, CODIGO_PRODUTO, CODIGO_INTERACAO,
       RN = ROW_NUMBER()OVER(PARTITION BY NUMERO ORDER BY NUMERO)
   FROM NUMEROS_DE_SERIE
)
DELETE FROM CTE WHERE RN > 1


DROP TABLE NUMEROS_DE_SERIE;
CREATE TABLE NUMEROS_DE_SERIE
(
NUMERO NVARCHAR(30) NOT NULL,
CODIGO_PRODUTO INT NOT NULL,
CODIGO_INTERACAO INT NOT NULL
);

INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG10062306627', 271, 12)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG10091500866', 271, 12)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG10062305155', 271, 129)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG12122602475', 271, 129)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG11103124806', 271, 140)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ZG12122602565', 271, 140)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'Q12F4300942EE', 251, 39)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'Q12F4300944PF', 251, 39)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'H8ZG0503172YV', 263, 14)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'H8ZG0502348EL', 263, 14)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G0402789W1', 260, 56)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG13118212Q', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1305999WZ', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1311823DG', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1312070D3', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG131206909', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG131206885', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG13120670X', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1312066JK', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1311822JF', 258, 59)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'5GTE0601898K9', 264, 73)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'5GTE176188388', 264, 73)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'5GTE060176388', 264, 73)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'5GTE060196445', 264, 73)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1619570LW', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1619563RJ', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1619568ZY', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1619566X1', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1619567H3', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG16195646W', 408, 94)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E30000260R', 3, 50)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7F4704703ZT', 260, 56)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG13059986X', 258, 61)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T7G0402786UE', 260, 69)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'16070298', 290, 70)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'ATCG080027572', 15, 71)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'88DG0600093XU', 117, 72)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'K76F5100628BS', 265, 77)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'170505', 292, 78)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'YSTE430098998', 404, 79)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'RM004200005NJ', 77, 7)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'CE12032900025', 5, 8)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'AOXE4700785PQ', 54, 16)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'CE11040800106', 12, 21)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E090004333', 3, 29)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'KS7F4512384UO', 409, 93)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'BO3B330086670', 51, 102)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'MPJC450065073', 13, 106)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'AZAG1206907BZ', 312, 107)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ604000079C1', 3, 108)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E4900107PD', 3, 115)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E460010BQR', 3, 116)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E4900077XN', 3, 120)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'TTFD1500108CB', 12, 121)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6E46001168L', 3, 125)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'OKWF3410385RQ', 268, 131)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G0402756TJ', 260, 132)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5G0604588RV', 286, 133)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'9IRF0500012LQ', 55, 134)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'AOXE0700653KT', 54, 138)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'9IRD4100079KA', 55, 139)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6D1400031ID', 3, 142)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'AZAG1208819ET', 312, 145)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G040279006', 260, 146)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'6XYB1100015WC', 10, 150)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'MA12021500007', 235, 160)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'IT12092806169', 232, 161)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'K4IE270018760', 241, 13)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1902686GR', 408, 15)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1905622PG', 408, 15)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1902689F4', 408, 15)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1902684A6', 408, 15)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2203563GA', 260, 57)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'RIVG2119383WT', 413, 58)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'9WWG0304322KM', 416, 62)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UL3F4700676SW', 414, 63)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'D61G0100337PU', 415, 64)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304217NW', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304216OP', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304218O', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304219I8', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304220SE', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304235P4', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G23042340J', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G23042333Y', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304232IO', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1B7G2304231EJ', 260, 65)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG23069825S', 408, 66)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG23069845S', 408, 66)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG23069831W', 408, 66)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WD9G2301898N2', 417, 67)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WD9G2301896QV', 417, 67)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WD9G2301897AQ', 417, 67)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'XIVG2700006OA', 420, 68)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'XIVG2700008M7', 420, 68)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NXMG2203323XR', 419, 74)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NXMG2501140D8', 419, 74)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900510XU', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900508R2', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG19005147B', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900512MZ', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900516K4', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1901596WQ', 418, 75)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'WQ6D4000079C1', 3, 99)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1612079RD', 408, 163)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG1612084XL', 408, 163)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'SNOG19026906N', 408, 163)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1599700365547', 302, 166)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NSUG1312485XH', 258, 167)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF060111660', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF4900874L9', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF490087300', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF4900872AR', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF4900871QI', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'34YF49008705C', 259, 168)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5F49028679S', 286, 169)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5G2003037I1', 286, 170)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5G060453674', 286, 170)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5F4801181Y0', 286, 170)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NXMG2203328VC', 419, 171)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'NXMG220332255', 419, 171)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900509L5', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG19005150T', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900507W4', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900513G2', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900511RN', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG190023250', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG190159719', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'UWAG1900230SG', 418, 172)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'XIVG2700017NY', 420, 173)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'XIVG270000745', 420, 173)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'D61F4500972Z7', 415, 176)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'C03F41000196Z', 238, 179)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'S5UG2000138QA', 423, 180)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'TTFC270006105', 12, 184)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'273920246408', 421, 185)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'DK5F1107760G7', 432, 186)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'CO3F41000196Z', 238, 191)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'CE11070700572', 22, 192)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'B8WD3800783Q0', 232, 195)
GO
INSERT [dbo].[NUMEROS_DE_SERIE] ([NUMERO], [CODIGO_PRODUTO], [CODIGO_INTERACAO]) VALUES (N'1T5G06045619I', 286, 197)
GO

ALTER TABLE NUMEROS_DE_SERIE
ADD CONSTRAINT [PK_NUMERO_INTERACAO] PRIMARY KEY NONCLUSTERED (NUMERO, CODIGO_PRODUTO, CODIGO_INTERACAO);

ALTER TABLE NUMEROS_DE_SERIE
ADD CONSTRAINT FK_CODIGO_INTERACAO
FOREIGN KEY (CODIGO_INTERACAO) REFERENCES INTERACOES(CODIGO);

UPDATE PRODUTOS
SET QUANTIDADEESTOQUE = NULL
WHERE
VIGENCIA NOT IN 
(
	SELECT T1.VIGENCIA
	FROM PRODUTOS AS T1 
	INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, CODIGO FROM PRODUTOS GROUP BY CODIGO) AS T2 ON T1.CODIGO = T2.CODIGO AND T1.VIGENCIA = T2.VIGENCIA 
);

DELETE FROM PRODUTOS WHERE NOME = 'teste'
AND CODIGOFABRICANTE = 'teste';



