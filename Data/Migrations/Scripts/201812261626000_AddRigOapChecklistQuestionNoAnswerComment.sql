﻿IF NOT EXISTS(SELECT 1 FROM __MigrationHistory Where MigrationId = N'201812261626000_AddRigOapChecklistQuestionNoAnswerComment')
BEGIN

CREATE TABLE [dbo].[Oap_RigOapChecklistQuestionNoAnswerComments] (
    [Id] [uniqueidentifier] NOT NULL DEFAULT newsequentialid(),
    [RigOapChecklistQuestionId] [uniqueidentifier] NOT NULL,
    [OapChecklistQuestionCommentId] [int] NOT NULL IDENTITY,
    [Comment] [nvarchar](2048) NOT NULL,
    [StartCommentBy] [int] NOT NULL,
    [EndCommentBy] [int] NOT NULL,
    [Correction] [nvarchar](2048),
    [IsStopWorkAuthorityExercised] [bit] NOT NULL,
    [WasAbletoCorrectImmediately] [bit] NOT NULL,
    [EvidenceFilePath] [nvarchar](512),
    [StartDateTime] [datetime2](7) NOT NULL,
    [EndDateTime] [datetime2](7) NOT NULL,
    [CreatedDateTime] [datetime2](7) NOT NULL,
    [UpdatedDateTime] [datetime2](7) NOT NULL,
    [UpdatedBy] [nvarchar](128),
    [CreatedBy] [nvarchar](128),
    [SiteId] [nchar](10),
    CONSTRAINT [PK_dbo.Oap_RigOapChecklistQuestionNoAnswerComments] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [dbo].[Oap_RigOapChecklistQuestionNoAnswerComments]([Id])
ALTER TABLE [dbo].[Oap_RigOapChecklistQuestions] ADD [NoAnswerCommentId] [uniqueidentifier] NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000'
ALTER TABLE [dbo].[Oap_RigOapChecklistQuestionNoAnswerComments] ADD CONSTRAINT [FK_dbo.Oap_RigOapChecklistQuestionNoAnswerComments_dbo.Oap_RigOapChecklistQuestions_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Oap_RigOapChecklistQuestions] ([Id])
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201812261626000_AddRigOapChecklistQuestionNoAnswerComment', N'Ensco.Irma.Data.Migrations.OapConfiguration',  0x1F8B0800000000000400ED7D5B73DC38B2E6FB46EC7F50E8E99C13732CDBD3DD3BDD619F136A59B23547B6BC92DA3DF354015541127B58649964C9D66CEC2FDB87FD49FB1716BC8124AE0910BC5409D1111D561199C84C7CC84CDCFFDFFFF9BF6FFEF3FB3A3C78C4491AC4D1DBC3572F5E1E1EE06819AF82E8FEEDE136BBFBF7BF1CFEE77FFCF7FFF6E674B5FE7EF0A52EF7E7BC1CA18CD2B7870F59B6F9E5E8285D3EE0354A5FAC836512A7F15DF66219AF8FD02A3E7AFDF2E5CF47AF5E1D61C2E290F03A387873B58DB2608D8B3FC89F2771B4C49B6C8BC28FF10A8769F53BF9725D703DF884D638DDA0257E7B781AA5CBF8C579B2462FDEA10CBD20B419FE9E1D1E1C870122E25CE3F0EEF00045519CA18C08FBCB6F29BECE9238BABFDE901F5078F3B4C1A4DC1D0A535C29F14B531CAACFCBD7B93E470D61CD6AB94DB3786DC8F0D59F2B031DB1E456663EA40624263C25A6CE9E72AD0B33BE3D3C0BA2BC79AFB7B7F98F87076C95BF9C8449FEA563EBB2615EBC230583E8C525DABCE8B2F9D381ACF09F286C08BAF2FFFE7470B20DB36D82DF46789B2528FCD3C1E7ED6D182CFF0B3FDDC4FFC0D1DB681B866D1D8816E45BE707F2D3E724DEE0247BBAC2779566E7ABC383A32EDD114B48C95A34A5B6E751F6E7D787079F48E5E836C414222DCB5C677182DFE3082728C3ABCF28CB7012E53C706164AE76A6AE77385D26C1A66CD7B252024D62C4C3838FE8FB058EEEB387B787E49F870767C177BCAA7FA904F92D0A48CF244459B2C5BABAAAE6C96BE1545453E6FF5788F7EAF55F40E2717654D77A92E0DCA6A44FE39BA011A0F9DB90DF6F9BD510FC7E7D72601A902546A8E93AC85AE01055F3D2A6964FE831B82F3A8C1C93870757382CCAA40FC1A674DB2F5ADF17955F49890049BCBE8AC32E3DFDBEB841C93D26FEFF265614BA8EB7C99291F4CD51E31A210ED385B7F4AE7286AED23B3CEFF08671788D1373E5ED6A47A6F476B54BB4F276C45B1DA729CEF2ECFA238AD03D5E932E6BEDF84E1EF0F21F6190662FC48CBD37047843623A6AC7F749BCDDE82BD732BC7E4A33BC76C1687B2BE1E5C2C5BF7AF9F3EB21DCEF65B2C2493FDDAFD11DCE9E4E92200B9628AC79FD1A938E89227381363938883150E88AE54918107CB9E2761A3D06641C9D775A77227E8A2357AC8E5D31227E0127385A6A42854F0B7C5A60971670EE5C981F88E3E54240DCE40C501A2E8F00138A720B8DAE344018AAD9A28368488B1B28D7D0D8E865A5948946C6EAC87531C9FF587CB948FDBA3C7DD6E76C0CFCEAE5EB1F1CF84007F91069E5F709DA3C044BC34CB00D8FBE09E9758692CC59B43B8DDC454E3FCDA0E0E7F30947F9842C1C3161BC4BD209468A92A250A42A6E11542B0F025783126894A8CAC154A80B9B2A40F289828778C647908635E555E2D36200E99BB2CED200C719800FFEE3077FD3A811475912879FB6EBDB262B10D4FFD320B55FA16815AF837FE2BE2379823AE102A8D52497C5522A2124BF64F1320ECFE264ED4896B3047FDDE268F9E482DF071C6E065F61F149994FCA9496D8C3A4EC245EE7C3727D26501504A564A2B2DC0AB89640B41AAE52C528A5B1CC2C554A28125183CCB2E336B5CA2C780AB12E5C41658EC697B6C891D9980252862792EBC396D5AAC411D84D138295A165E53A5445B4A2D7E52C24068BAB931524A8544AAB9CBE720C8E53FB8AABCFF06737BDE7708ACDC154E1FFDCE2741CC549F71EB1B2D9E6B93EE3DCFF8CD3681AB077D6A90A57CA34D5367431D9988BB8D561E983D6DC82D67CDDA99F36F04EDCDE899B783D7ED8E6C2F1B15CBDEFF3BECFFB3EEFFBE6E5FB3E04A4A726CB8727374E8FB2F3DE0EE0ED4E885D144DFF23ACE90D7BD1A82EF63C3D4FD77D9718CFD33A96F6DEAD5D63F5023DC55B7E96464DFD1925A45D29C40DA97DB4F1D14669891D8D36CA05BA6E7F93CD98D02EB5E0083AB325D272A299127961D365889387205C91AE5F730C24A7CD984A0544526DB8B23A8D780253AD186F36BC4682E54798097A2FC4D46072BA0E5332F579CEEC375AF9F0E6C3DB50FB4FC2ED3AD2EFDAA8E20E2D2E5E02E896524EFE33459DAD58977C4BB683B8CB92B5779A10A719A49B103D4DE3BDA6F5D8E7E9DF71FA29FE84FA8EF72A3627F136DF86D16735BDE2F439C177C1F7C13773EAC6A93E02FA0828AC69A603BC7E9150B56F5112346D23213DE9E222F655CC7CB49BDBC2CFF91ADDE38B788946B9FBC84FFCF9B8A0B4C48EC605AB11467D74CEF1E8A266EB7DEDDC7CAD839DACE7E997200D48790767D5DCDEF1E45DBB77ED4A4BECA86B876E8155DEACD3F71CB6FEB8127F661BAAC44DBC0996FA89BBBA82455D5E2C39534C3975C79675367757F0731C560B9E3EA6CE2DA6564DADA8E6E79FE611BAF511174E5FF79CFD0DDA3E7CFAF0C907A1A2B76BEFA4D315570625198DC5814DC1486F9820AB4A0F640119AA477D9C4D9F2194966B9557350A2D06688CA6ACB30CA139A4E73449A8D9FA3C616E7902E054E60F2F5F5AF93745C72FF0EBF400ACC8422E129CDF7170FF401706AF491DA17950244205EBEDBA9FBA7FC7E917146E954376171A9FAE82EC533C4A55D778A943B9A354A1BC92B8E87C06A9E5AF280D9627689BE29310A569701768D703DC08ECF2EA257ABAB2475E5D7B89FCAED39C85212BCDED468E1C0CBD4BE1F91E0AF2A383E7353A60FBA53617AD09166A2EE20C1544ACCC5B611CFA0C296A6637E8FE2302DC96A4948832B1B047456B6F8E9A411F6B14CAE355CDD2DE224246065611D09B5B46C4A48F75AA39B261866FAAB1A76CA867A0048DEA46EDD9A2D2371E2D0C6EA986C2F8A441757AABE6F601A322B987EA26A3D768292683E92BA1753E146FBCF22043F29ABD1F9AF73F8D6917E9A71CFEFB3560053F9FA60EB1BDA79BDF0CE4D54AE6DEA719BE6A569BCFC1F5C8A226E9CBD6FB8DFDF01BA683B9E94771AA6CDE6818D8734C0BB64459AF4C249D2DD4D4A0FC58C3C2799A5C6835542CF1810410488A1618C7EFF908B0E311C0B8AB5FB43A243F0FE4B0E7AB2BF28E60061925D32C868B51DE85EC870B1927891C62E2DB389954CD9E3B5816505A46ED0F55628AEC64CF4D9A74F660E9EC2E64C7F720FB2833B76D52E5135C9777EFD053BAAF5B8BFD5CB0829F0FC70E337AD96A9DCB3B95BBBCBD47057854C0763C37A7464675DDF2CD7F869EA0D90D387807058DA07635CE788FBF1F1E7FB80198DBDD1CA0E1966627886DA4BBDEDE5E3FA5195EBB096E949D8F67FD776BE4B54F772DDACF83D49E63A40088BF0FCC8786D98686DA258AE30175728B56D18EEB1794104D0F898AF59DF271EACDBD2BF7AEDC7B60EF81E7B0C09A3BA5D3AFDB6033C07BB494AFF775005F7715F4DE28D736BE035EB4FDFAF29A3839EE7F59899F55F18E7B1EB32ADAD914DA69418FCB8A4B2B77FA49482C4E64B5E28E89522D328052CD1F60A59A3FFA0E1B1C47561F50875829F679BC0F07730B075679FCEF71F28FF32825DCAA053DA7D93CC3DDBBA09DCCE99956F499BDCFECBD2BDF8DCC9EE9BAA0FC5E45A34C88958416B93E179BCC95E5588055667F32549CFDA9EFA8609038EDC3B3C5D1A5206BAE8E17F4F6D73FC2B63D99DE5ADF3453B9C174FC710269239CE068A9F1767E90E2239BA3414AE962CEFBACA2E6EFF284C13F0B92175D9EDEDD010F685526EB7B22BF6213DDC52A48B9D834AABB7BC5451DBA5B2F7F70B3FFD54F09796F3BDC38A2EC92D2C4BAF1958B76E96E0E2D2C244C97C5257B1FEFAFC5721B217C7470365DFEE32BD84C8EA6271209EFE344D5117FF2F75C798FBB23F9ED5570DF9E42384E539CA6B18B934D12CE7BE0D0DE6F83D5D073EFE2B9F3B266CD103DBDC08852D85EC3FD5B8A93BEA9761E72FBE7BFDE833D4B0FA6CA1999FE214C1C99328BDAFF742E439016E28EE0C84BF63A70C369E2DAED7A770B72B7D45E04915FB78049869D9FC91DF7446B6D5E676EF4AFF1ADE1F1D2FA69ECDE51CDC9C2F8D2D9C2F8B7A87FA4BE2650DEA6FD63B52E3339DE66F135517DB50D71EF14E50AA37494A7587C42B1EF09452B39709F4AB07350FAA4032A76F57E0C4CEAA6B05CE8BA8C56665AB0CF6B0620B1655B0554E5B4E2F7DA12A07E478FAD4AF80C83B4905672F50B7A2AB149B617DC0565F705C8DD2E2E17BC29A595BC55B4D75C2BC397BEA1E43A73AE18FB04BAF77C458F6D835523985E98A87D57CBD5035E3E37D8FBDC40E86CF40EB42ABA10924B1DAA824AE76055A4A6B1C26682C528BFD04DAF7089888B50E1F0A95809671F2CA60C16B6D7EB6AA305F9A78B15BDF8384ABFE1848B69568AFBD0B3FFA1A7C40B689C41AF85A234522FCC16D50516AEFC90C3545A19209C7065C19A580F5FCF8268451ADD4C958648AF4A5D16AC0A253055857147461A71B47AC51812B07E2C9D8BA7368D741533D02B2CFC11AAB5F0C731B238C3E90A5D1EA77E31B26F22572263B874AEE4EF933AE3A48ECFC4EC92BB84B83614F65BDBD0ED907593DCF9746CFFD331E97072D8F44CE363A5E99C4B4F3BD82C2B5381F7B593F95A79A38C7B6D5E5165EEE7FA1F43D60EEC5FBFFC61986DB465CD8D0FF4AF47FAA0325C50B11A2B43C3CAA053B1D5E875B8B85255E0E30A20AEE8F6D3403365632F479F3BE8BB8FA96A6D27D1A3E295737124D6F5F6D605B713B4410E36B10D904368B791016FBDD56D23BBC21B120EFAEE1F3B4ED3E03EC22B175BDDCF02E51E4E3763CC2BFC18E06F791474B23BBFB5EBB5022861443C060A474DF87C8EB3F7394ED7FF99A43615E582E5A0CD73C484D0F95709B5E56A414FA5ED34EEA1AE95AE2EF258AB8512681ECBADACB8CC63B90591A1F259A6229FD7FAF99289E6388AEBE71C4D749C462B5753267192681F85039B44978892C62B6EAF3ADE660F3119C63C9D7EC7C93248FB1F6EF81DA5C7A47416570A9D13EBAC020291F0A92FEBD3C76095DF9F94E7AC046F0F831F99F71715FAE473B727D81CEC7780A629B27D122EB2956A0BFE002BE635679F8F0C7CBA5F1FEF1D1DD9BC2EE6462E23DE8769D7EC1D5C6CAB9E4672339DE2AF38F0516B57A2D63047B674BBB704A7BB5C84A13C63BE0BE36FEEC350CDD97D183AF815A5B86AFCDCF6754DF985A88824D38750977F61B1E71D82920B204A6AC1171CAD14323212DDF49294AED7F9BF9AEB4D82A234B03ECF51B379C1F31B003DC7B729F9BACC2A37307A5233C253EC05166A63E621BCF742D74DAC66A75B2DF9BA0D12A2094ED6419AAA6704FC956D3E1B98713620E85C425FDF29B1683C5A67465D5A88CB07E42545E9804A01A62B2B856FEA597064BC16F2D25C78029038894C95AC2E8252C16A0F06D5634C844719FE3EC2C0D87B79EFE587F1F21D7FEDDEBBCBDCA13C0E5879C1E3CD26891F51E82A3FE7F98D37BA6BEB70A4D6BAD84C944FCD39D35BC07112CD957D84FCB9DE646771F219C79B662ECC766DAA62178499F269119B094030804FF2F17C58F63E578D29E6394720175CD307578A73ECE6A8F3155EE2E011BBD29963374F9DFF28D7C9DD69CD319CA3DEF9BA862B95BBBCE6A86DAFA9566E34E207228081C847F447DC7301EC6310F5654127612FD053BCED7DCBE831E9D98FBDA37B7ED3E1FA367491B99B4E25167B28C7AE75D43B768B2622F8FC1B5A878E53273F08F683E0B106C1F079C285766E70019B0F5C0C300758F7463781B7E6E603B0B3D7801C79DDBC856C56A7F854CE904151A926ACFDE840C146C0112AF36145C1CF879551C24AED6BF5E1455C521A6624C54D0FDA88068126EAB4E9003AB516CBC08AB517D85C04D37A938DDBA0CA72DD83E03AF8DE55D6763D0FD1B008EABD1D137FCDF75193D6BA1DDC8319ED2F7173906284C976FBC7380ACB6B720427E7BFABAAFEAABEACC08DC57D42A2E0E7131207094913D314419C0D550B9E9A0FE55A226940D753DA262D74BBAC95B60DB581B6F507736D29A5D324C66DF2B2877B55C74B62EC86EC030DF70D7DB0A30CCC0738053F1FE09CEC660239FB857A5C2A28A675E80BCD381412B060B237A51592D3E966ADDCB4A4ADD4FA590EAE2EE92C87B8245C09F349F5E3348D97412179A557E74E93F2329694094CA7D1EAA0944454B811B7594DEF5CAFF29184C66043822191E7EDE1CB172F5E7156D7D440374F7335D05B6BBA95FC1B570389A038C963180A4F48AB91281C44191F6E8368196C50085097A10506EBBC65682DEC97777883A33CD0026C01A99EB9668D978456C824143A63BD396AE1480D2FDD333A52A8E90845B0133E08A443864195021C764F1276EB7AC5B6D29BCBE81D0E71860F8E8BED3CF986B8748956BCEB27DD77E500C0508D460033B43D21A2B067BC274776AEC959924F9E44CBC2E78260CD51E9306D0B66BE223192BB2ACC1ACD52954686B2B40D8138EED0CE06CB44D42C5EC6E1599CAC8DE0CC120E8968AE2E31A8395D668F6B996213405BD69E4074B3E4B30078B96D6F711287DB7524CF75E5243A5097A507C519484C4DBA52962E0B0F9440EB6D3832A6C516820821D8F53915923F043841C9F2E169C1424E0112299104CDB4BCA18B96D703822368B8688B45AD6CE3A051DB143B8CC7205C11C6F52F81622E4147688A4BCDC482B63A313C0DBA810B544AAD303E32A5168288F219E596A0EC6611F7F37CA69E2F82E698DCE5C6EED358F606E43E7077927E32024D9075325607269BAD370066813523A00D8D321B88CD6F6434312E2D40391B44BE4FE2EDC67CEA9527D3A1B4A0B085AAA0BA9D9E7495EB33327CE5EDB89313AE549DF709DA3C044B332C5744E320B9AE4C8CE35AFE51A2BB4CA6A9B0C8B403108915D52C7078136F88FC3C68200891D0EA505990D9A25256A7C6C90A7BC23018D548383254356D64EA3B0BE2590057F91CF63B942170F60AE2A403757375B81DAE61426850CEA93F0AE08D441F19FE466D6BDA19583EB3EA1737E8FE23DA08F5269F8C3A869A15B467945CFAF60F8D2CC00E925B60D669B799BA13752A182E6C7B156131AB0E25D3939800B6060761641B6646589B03890FEF7F205F306C6C626C3EA7D0C4D8D3B60F4DDE812E5AC2143B4EF1AAFE93751DCC676D97B267ADEA646AAE36D1AB879CC0DE347C9AD75F87113B577F6098763786CDE4BD4EEA5E7873F4085D0266BB16BE442A283A5D5FE7304C3853B4C31C429AC2C63B1BD65865E92648E3DE4429C79C60682AD56CA31D7F0281136D4208736D03C42BA59B174EEBBD8CF50F1F30CA9FE332028F98872D76F53B5EC012A8B7CE322A8FE8A8D5069B0ADC6A23EEB45B2E27BC6B9160E90D4363B58031420AC38A69393C1800EE12034EB2D6C1D9C714CE059B5960F97A7B5BAD1DE522C1B0CCD0E8B05C179F00CEACA41A3803970D7B635962C091B12C318E29966B36B38073B5F258890483334363B5E361042CB3626AB02CEB7503C05962C091E12CB18F299C27C7727E4B75FE5C39FA8822748FB943A0DACD13200612940B680D4783B0DA6DF652CC62F9CC48BD717A80517BEF5C77201DFAFA29CDF0BAD8F45CFC4B057E417109D4694943808B6A10C359CC7E16305628310E6815ED0484684934434FDD00CBDC4D366619D93F37154BB02CEB2D4EE7EBA0C24DEA58B9368202B6A69B2366AD013B0D5A77D4ED82D49916DCBBE98A69BE72FA751B6CEC6ED01193EA868394CA76D54452ED4E1FE950EB34F2C050DDAEA609F1FC50DE20D0186ECD1FA3A2BCF9438C72696D334639A7D39428E7DA1588724A370B94E757F8E5F7F925DB25B7E40FC2BA8A810EF10CAD2DEE9522ECB48F876836721F80B4F74EFA7B81622C3E2DC1C8FE3459AF607F12F70D4DFDB3EF21122DA7EF27121C007B0B433D699F292F193FAFA696AA3F95DD434821EB094D6153F08BAB91C4804AEC59E25BA9C8485056B619D4C7574CA642EB5570DF8950F9909C144AE4CB96520A115A99C2863BA3E4550910CB14AECB0EB4F6A8B5C20818D49A072203C3642E40145D3D5B5F150C848B820500AA16F7121BD4AFC9BA2595BB9BE73617757C3C03DACF3491AEC8E702F245250FDCD9D60416BE76A0ED215209F52E1ADCC59C7868D674133868D6363BEC9F6113212A220B081B38DF1D9FE480683301807B4C662CE78660BA4BFC384ABF6178C2CBD201703CF279309DC07ACF5C939414E33868995DC787B9CC6016EE7AF2330332D54C330F8E7077606F9091D434A3662652D34E887C0799CA5CA15FBDB6B3605E26324495988B41A7A8087BA4381A518C1F639A5DD6035370BA5EA2C60044AE2EE5CC7B8A836E32973EA2E920BBDC3B66D9352CFBC51C3B45AD9279E65413EE4EE6442586674EE02EEB3473624D3B61E6C4DA6C8F32A7C5A7B81C11194EC4CBE87B7504E310C0D50E0735ABF758D3F23AC34D08738931ED259A10D642C099A24BF8A33DC02D721CB108935FAE6523ED84C056B5A3E972D3DC1C39E0BE0829C57C579C94374558773727D3F6535C15A135CF2EAF3A7DC1497017148FC543E1D1900CBF41A555971E8B55E1B176A8F07698008CBC8176188DF48DFAD6EF1706CBA1327A004E6BD21E6983B4763D72673F37A2D36D7CE4EBDADAB01B5C4CD90D6A5DAE3394E1C54D82A234506715520A11D43B8547CA29E4020A7A435DB82936900BD79A6D041C6B2D0391A114B7C36A72F436AA2C6EE22EE674289193AAF06C0217A33A151015F62177633BB870232255DF3A106118D2C9E1BA3083E8020C4B1B302E5C03D0C220B9BB7F24EC0C0D23265319A8A6B03194A4B6E97BAC5AB0117BABBA3D2082E484F3E8A39C2E2D976F8C94961B1B0B9C6DCF6993F68C00535EC429B1CAB71114B05DEAC9919B1F9C43D112731A527CE9C0A4E5A042314B6C8366BD000A4CCB2A9E7E646BACDE88FD01DCE626BDA2A69D4D9F58187871010D04F77DF0BEE8EBB5E78771814A13A05AD0863BEEDD69FF84E39866FC43A39856A4C0F0F0F986549C29F0C7DADE047DF3C31C6C7826261B0D7D73199EA9059B128C56C3B3F94CA34853160A23EB3C939A6AAA44B7095C72FCCA7ACBFC9200AD7A734874D9363772D115ED487DE294D0644F8426231438A90D94ACD125DABCBBCD3FE0EF0434CB6D9AC56B14457156F0F8E5B7149F84498EA5F4ED61966CF92E9233BEC69970537B7A785016509C43E0202F64A8E106627529BC7452C4555C1252015DF3ABEEFF17F2EE163262ABE368C48C9E0353F3A43B1FF5ACE9B350B2F662CB4098D62FF99CC5C95AC1972D0661FD21C0094A960F818C695DE0C9C8B017E829DE6AED5A96B2607C1287DB7504635F968554F23E419B87FC091621DBEAAB91B4CD33186A499BA7220C9857EFC5A839570FAA18B06D76C9A939379BC92C98D7AFA9432B691EBBB7A8AC7EBF195655FD6CB15D4506B580ABB868D1891EF794D7A8A634F16752FFD07A4610EEC8BA4F9269DC19FBAE9BBE1A7ACFB78473EB2A7500332527301B8A007AC3A70E2AAD3B58F5EC755C8D9875F6EDB46E95D349CCDD0DA8AF0A568305E3D6FD6432B1DB17C98119AA99691949EEE91271955EE965560580B5294B45DA24BBE4C6AC02550C92EE69B6ABA2BEFF025C517D2B04BCBAB617869B8E3B8D6FA71F3DB007AE901E62B3D390391B63503177D0C84CE37A4731A0C666F3B1A60A7E3A5BC45DB4CA00645CCC0BA97856536E40762A4E6026D5385F1CF2F935432057661641CD9D9F2932AC05C29C63DA9A3B108EBF17CDA8BE55941F8837E5D8898D663E4B549CCE9D51EDD8E13F3753A26158CF85F10C1B55D809ADAE1500161238FCEE0559026B6969E48AEA48455614472F8535B595082CCB445DA776ED3C555D8E84D446E50960CA72743A73C2EDC8B3161B919D43716E487EA2446F4B8E06AE334BEAD6A21C77B1510573484EED5A4EB62CE8CC8CDAA24C6998B65D229D15E91414D0960C774DFF66E6A15C9892CEB42DB80932A131E5E5950A4BC92406EDCC10AA6D29670DB2E600760CC25582A38E0A5A5BF23460A53952B736E5D98BEDAA60EFC07BD2850BBDD3145E2FA5F466EC55524E5C247B29D498D6829ACAD04EEE8D348985CA97514D924501054C479E5067BF7AEA1E684441052327895402BA5601B4655DDE50D18A6C283BD6ECC5566C566B9CDAB05830113CF7AC31A58C0CA6B2845A67D87A05086858592D1A948A9BAFA79995374E34AB3D6AA3C398C08C03E2A56B90D6BC25B04D60D56A5A48B0AA364863954B6342518BF52C586B69B898D94DCD0CDA5E7485D0B0D534B5039BAD5C361CAF7B516D7BF4AE9A87039457AC46EE5B75ADF0361221A44733A9D7663B32339F550DD783ABDEA8F6CC558DAB5DDE0634770FC9800018A5870AD5B7E8A5223E3DFA8C80DD48BD5554B3A2C10CA1E4B0095BDB20E0EDD510999B88D20EDB124D35EAB95AF743432A856C1F08D0CE1272435388B90C687B4985EAC95D6E5FCD0043A3964E902191E4D235CD2085BF78CDE51088BF336D64E75FEFF75BD4E2AB2DC91687E9CA50E92CD9DAAB0834265B81C698E2A67232E5D1921D32E3D114379991A05483CC7734DC356694B6939D2505DBBCC1B31F305AA515402C240617EF65575B1D56DF883322742F6231515D6D27145A5B5452A9AB804062C9F68649B5FD443CC5D69230748AD2D6464E138036643658694C30382C9BAA243696B69B5B33DBD8B88781C7B2EE68F0A59E836EC3355AF39050C1C28B985817C3DAFB8981714C52D1C86B201D295ABB9E0D2CDC505928DEFC31B0859B3FC41696F3EF69616633B6119295B43023A858E86CCEEF36075A5E59E9C80817C8C2ED8F376E059683B559D89F466C11F62771BBE86AB46C1DF1A3F792861017562BAE7C6F9D356FE7F083C6A2CAC7E4C58C5D184DFEF6BAC068C087DA3BBAE99F6A6FE9C61F9A50584DFF32BB9C734B4DD72654BD1AAEB729F8CD71952920AF8ECB6D03DA996BF1CEB8E1466007606E58EBB12C7E8C520938EE194A5748E65E8B346F2C07D6D36514F0D79895CAEA32875E961C3B43D0BDEFAB372347025696A504181336330E7DCB575F0F35C3608636E8F23C8DB9090C5C403F5B035D427BE96D38D7C09C51639F31859B1EF20E2AC43C9A9750F58DD29CCF336F1BCDDBA7ADCADD1FFA317835D3BA559C34C974EDA1698C815BA279AAD1C021899F7704F909EE81C7A11C12F72EA37DA33AB4367778156E74E5C3822093C89E161CAA09648F09EA43037F3A78B01611FD68D22C427A735B097F1CBA81843F8EB8D82D7F7A0D90CE43B60CE85F6A7395C82B370B401BCD81095B8F7F016C287B2A4CA9AAE0B130575614BC0D2667DD3AC9EFDA8CF45651F6D52ABD4DA5A4602BC83888AC2D38D00E37B7B422BDED5DD89CB9B6B37D77026F657961B9BA521A9525EBAB16146694F315184E78378433DB291EE8511811FAAC8F506BC0C33E66EA9BD6A230B2B8F17AD87701B6A9EA0E5FA18692DB7B055AC12C26B99F770C2B499E9951580BF2308D504BCDD334026DDB378900CCA8798D661273B66F8C31B0A9EC4E7E98DE82DBF907B0AEE062FED19CA7FE410F85B50D5F03115A03FE1E8822E41BB600FC0910A3D676D00C0B18CCB54F4E28D5163D3A619D4FA9984F86E6E6010388116961032D69C4716F40CA5A61BE418DA68D5C903BFB613A6A23574F1B8E1FB8F417C7DB3854F1ADF366CE8DBB777E0487CA5D356FD2C48A56C82F93CF19D16BCAE9B73747D7CB07BC46D50F6F8E489125DE645B147E8C57384CEB0F1FD16693CF743694D52F07D71BB424CA9DFCFBF5E1C1F77518A56F0F1FB26CF3CBD1515AB04E5FAC836512A7F15DF66219AF8FD02A3E7AFDF2E5CF47AF5E1DAD4B1E47DDB3076F1869694D599CA07BCC7C25551349CF82242DB662DEA29434D6C96ACD15E32E65EF9A8FDABAAE4E7CEF3ADFBCF56D70355DFEEF92F6344A97F18BBCDE17B9682FAA8AD99BDA19968D6DCF88BAF96C66A139962EBBF00C088BEB250A5152DF93DFBAB8BFBC5B487E91BF9CFA1D4E9749B029C36D9B4DE7039C5F6BBD82158CF904E799FFBFCBAAFC05CEE124C1F9F93ED260F8266099711FE17C7FDBACE47CB98FC67CF3E93B01C75FB92B0E01BAB3BC5A3FC3795D0719D7ACF56F3C9737470CE6D97E76C47534C6FBB1FDD7A4773BEFDAFDFAF52E776ADF017D0734E880979293172EFAA298B745B784321AA687B667D18B13622C3B610123FEE5A11401DFE68319BFFAFC908865FBDB747EEA32290E7B77844B04EF00A8785CA33B4C52CC84A4FEE433D3D3986F0692913F8A241E8562D6C202063E260C087AC5ACD96F70AEA7D16390C451DE3164724B8A18C496381273EE7C80F33B16733BB6E155BD20B5E45C6EE7838F8206BA3FAB28D8F5E0CE026097AD5DECD3F1D88DC4D485C3BFA4D7030A025BEB8B5D7057C57533AED7194A327117673E99387889D3E87CF003052D5FEF22FBBA48F7DEB1A763DC559F989B2289C34FDBF52DEB1B994F0689108A56F13AF827D36F5A3F1B7947D1EC60EB67D36189845DEB8B1147F6F67B016B5111A33A3ACF16082AE0BEC3B97FC0E1A6CBAFFCC5471A1F697CA4691F46741D70247BF20DE38E94CB6E849F61925F17897EB3AFBFCDA6F9D500F2DB5B31B3CE87FD72B8DE5D3E2F77C93CACE4C8572A5F9982394A0D8BDDF092BBD0E37D8AE57D8699CFE0DF0D73E436740FAAC13C879E8B771EDE7978E7318DF3503FA266E536E87B6876FE42413E8CA3C8373DB233762B2310BA7635E7E979BA66542A7F32E1513B5E9651F3BB818DEA0164F90E206B70C16738EFCF282150A0CDCEF2167CF64EDB3BEDE7ECB499EEE67E4E4DFC4AA9E1949A8CC96EA47BBE57FA5ED9AB579E485F4E76D1374BEE4E7AA88CD540FD344837217AE2BB57E7C394B9D7DF71FA29FE84D8B489FE0CE755919CC4DBFCBAA136BBEE17638E9F137C177C17B2AC3FCD23B7F35ED47B51332F4A1F8D75E437250FE7C23CA59478377298F335BAC717F112F11C994F7E44E5BDCE73F63A34C8A91E9EEA97B7D59C7BE66C7236BBE1935CEC29384FBF0469701B623647A33FDBED9C18E24C90F797DE5FEEB1BF94BE77D8CF59166C7B7A4A098FDD7093A5F01D4ED54FA39FD318FAC82417DA5455B4CBEC9713F62EF499BA50D565BAFDBCA8EC4E6443472A67B31BBED4DD16542EBCA85C152D30AEC7FE1D07F70FCC7463FD1B9CCB47F43D586F994568FAA3D184E517146E19B7D3FC6AE06F5741F6291630EB7C30F0137829D84A5CFF68E2BBCA23CEC59D855DEFD5FA00E7F72B4A83E509DAA6F82444691ADC05A2F91B7929784D8ECF17D12DA2AA9335F6D941DD5F736F2739BFA32C0BAFB5FF591EFAC440775749F5A3CF5B207C7DDEB223794BDDC986CB5FEA1A1CE5317276C3E433F3DB60E6277C7CAFEFD9EB6FD03D29345C9F2FF93BEAF13266C3F4779104906CA57F2D444F48455531DFDB0D747FF6BD7DD0AEEEAE9F8FD5C9F3AABAD3B3F90FBE4B19E8FEFCBA54FB9DB52B1CE6DAD67F3A0FA6EABA7A743853C6FB1264195D5595098A7ACF60A0FBB3F20CF5DC98C3235874BAADE761EF5D9DF12FEF5ABABC7B879E52669CDBF9B25F33717E54EF5D8FDDD1F13A507DC068257E57BED701F22EFB7EC7C875BC867150AE168B9C5F3B37D8E2936CB9697E39DA2EB866EF589F9763A557B33BF3A594A39DFB54903F97450FD7B7F3FB74CB7B0543AFE0D825F4F107CFDC19F8CEEB3BAFE59AC8E9D76DB019E62E53CABAE77A8882CF301DFC2AE0161EAB9FEC460B0EEF30451B6A0D01D7CEB7DD3E15E5C741DE69CECD69BAF7953D5DE4E89ED1272EBE0F163CA64F5CF2878FF3478F93ED7298F3264C053D93182DB76798CA303611F01694F0698D4F6BBC4B75E95287F2A44E1CE8447EF326C8D80B19AA9FE03C5A628B5E52127C36F0EBFE5949DFE7FBA451DB30DB26F8DCE50C6E8BA765B2A462304C3F6FD52AC86C9A2F0668AA88A2BB98C153FBC398B3CD8253A6C6E74BFD40CD7B182B0FE3DABBF4F22CBB3A4D724260721F272C7CE8AFBE1F6BF9FA7E6CD38FAF82FBF608FF384D719AC68EF6D449985BF47030A7C1265954732482CF068388F4022356BAEA37834E90E28415ABFECD40CF981D1395BF78E761A0FBB3751E83388DFECE62442741EBFC2D0ABE6EF9A1BBB0C4B87316CE33975A214997E73FC379FF35BE654D58FD04E7515F1ACC326AFF3EFA6CFB5231DBBEB49C6DFF16F11180FE68347F9D6D995328F56F2641ED789BC5D74497D536C45C74633E9ACC8AA194056EFD9B0F5206BA3FDB20E5F4616731EFFE216BE4E79D874C6F056AA996185B454C66D0DCDC5FE5FDC2F3F50B6EAFB59430EFEF19C6BEDC722CD730DC792B57CEE1537C1CA5DF7022716282CFDEF118E8FEEC1D4F099F41DD4F59853B2724E3378A2B92790C4531A39D40418498B748E98FE3AECC79E7F03C9D43FBE29A21472D4C1DEEDCC3B4A39861FD835C5D4806D367949377496132537E9860D45492707DB4F9D9FB3A03DD9FA5AF6B778EB3202271D6D1057EEA3ADCF93A29C3817C9DA379507AEB062B0EF309CEB33204EFA53A1F8CF989AE50673E19F3BCDEDE2AD8B6BE9AECE3D820CE94D56FF38C64AEE6FBAFF086F82976A2BFFE15CEE9384D83FB08AF440BDAEC3793166717CECA5F4C7ADC6380BFE57E582419FFD56EDDB0C2DE39715E09196AA8161005457D9C35D0FD59C6D9F6988299B11A34DE3275B98BBB5AC67EAC31E58A4A71E449324060BF199D8792F0EC7E31D137494477A6B57F37898604BDC5C196E36DF6109354EAE9F43B4E9641CA2F85AB4AC26BFC1DA5C7B721CEE24AE07362835540FC59C8184859D0A0051E83557E06258FA29F51F6C0B402F7D51031FEFC9C8F9E338C9EB95BFD8293E02E1868A2BE66DE3F3ECA39EDDE3AA1B360540C1E2ED96B31E9AF46CB032E0E0A3B1878F97DBFDE258EEE12F37CE52E8CBFE5075C1189F383F8C2BA12BBF3400B09374E547953387388176A87782175887D9B57D310E769FEEFCBBB7F91B508DBCEFF6AD1162C8FB1EC4FEB65B8B47F37E7963B68AE7F721FCDF9DE24284A03D110525CC2602C52D99DB366EB77834D30C89F2EF381C2385034E0350B15600FD554D0C747355C46BBA83DDE264BACF42E922206A74662257FC1679359F1AFDB20C1ABCF38590769CACD9F88BE7B6FA3E5FBCCBD8D650279BCD924F1230A55DD18943BF28C9CA78D5399A85841CBEBEB6F2401ABD1B26BF2E77A939DC5C9671C6FD8B12BF7D1986F1066ECF8BEFB65360D7A92E77061581C65EBDDA46266FB82FDCFDB5B32127CE86D258ECFBE18E80A2F71F0887B1B88E3B33F06FAA35C0C7260228ED3BE18299F4FED6D9F2E93D999A6E770A848B4DD4C9A7558F618FA48E88789DE95F0EC847EF5A31F1F68F93EF3F141CFEEE7B6E7F5E87463F5B78FE88F984967AB9F0C780411C7A3FCC90071F56CFC057A8AB7DC9CB8E0B3C1BE41124E1F998E56FF66B4FB10AF6FD94D13CDAF06B32E0440CC444BF10B9C83EB9B3A0A6B1008FE0DAD43819DE817EF7FB57CBDFFEDE37F2BB8B97A4098616BF388B09EC5308ED97517CFF5902E51CD7279AA108AF795AD9F0D5C2E9541E07C996FDEC969F97A27E7626FC440CE8E61DFC7E9E9590DBC422F59A1167D37E75E6B25E3DEFE6EB6EE858B5D76B7FC8217FD309775B4F9CD966BECCAFBEFCE07637E7F151C966B7DF0C140CBD7070365302023C47819140B27D288B0E8CEB519387B96123A9F4022CC4AE216BB2C173728B9C7A2633920BFDFE5256A81DC7E54146B29CBAD10B6521ACB459A6155A48C07E7E9A76D18BE3DBC4321FBD4BC4EF73747426CB4CAD4D8CA5B1D05114ED82214BCD52FF4EFB4FE210704BAC71FE3150ED3862EBF62718D0A73A41BB4C4E5CB026741525CC7896E518ACB228707C406F9A18D8474A2E2A9DD1288D75FC3933028B659D7053EA228B8CB3D71FC0F1CBD3D7CFDF2D5EBC383E330402921C5E1DDE1C1F77518A5BF2CB76916AF5114C559A1FADBC3872CDBFC7274941635A62FD6C13289D3F82E7BB18CD74768151F115E7F3E7AF5EA08AFD6472C79C516C4E5E5CF3597345D856DB8B452AE0A24DDC3BE5D68BDF92FCC61A2C6CA15BE3B90C1EACD114BF84600CDBCBEB787416EDBA23FBFC7A4E9733FF81965F991CEBC142EC43D3CC8D1876E434C1178A4645FC6A4B282E81125CB0744A2F047F4FD0247F7D9C3DBC357AFFF62CCB43324EDF2FE9735FAFEAF6D8659C25F71C3F2634E6FB7CCC1B6FD2FE7D10A7F7F7BF8BF0ACA5F0ECEFFB6E810FFE9A0D87CFFCBC1CB83FF6D2A0517714B39F2E09691BF5FE7C0C7CB202D10FC3F8C8DC605DE41D8E79113DEDA066671CFB80ED115579EE54B35C776A086746CDFABC7EDD5BE3FED697FBA449B7C19A4481C480E40B20DFEBCF5CE76ADF64991F749BCDD984724010B595C828A54666256A2D4A4BD45D8DEF691A2A1EE13A3153E8AC1FACFAFCD952CCFEDB5743364708DEE3049DEABFB726A4EB78139A7CB4D8E67A2250A5DB02B3377179C4EA3C720898BBD9E6E44FB14472ED81CBB60D2794FD17174F5D1506596DD8E865D6FBF278170EC1C93699DD73F98B6786FF74D5AF27D82360FC1D22AC451DA3E018E3D1A6F9F79F48CF8CC0D1B6EDD49E7B20DB7ACBD9F5599654FFCAC77B172A6B62E16D6BBE2284BE2B07EC35AC1FE2773E657285AC5EBE09FB857E68C3676F38894D0C140C95A024ADB3386905FB27819876771B2B6168667D2D7346749BED61A2D9FAC656238F412E8030E374A0CFFF0F2A5C67BF9B8E9E3E60EC54DE1D5883B1B3E071D4CCC250FEF3DAAA1CF04B936118955C3F1F65E54C4DE7BD109BD6827F5D813173AAB1188770CDE31ECA26360C749DE3778DFE07D83F70DB96FF81090EE48A47EF24E41D1D2F14ACDF4C797B37234E7E979BAEE3349799ED631A3D7AA3E7F48DA6C98CA31E833EBF81925045314EFE6D2700CFA48E3638190BD8F057398862BBB9B8F0872A6C32E62F93EF65CFA58793CC7F734454F0BD24D889E76AF179FA77FC7E9A7F813EA9342552C4EE26DDE60F693EC151FD2B1EF82EF6E76CF8F96DC799FF9CC7D66B571CD7B4939D34147936B748F2FE2257276F2C60F7EBC93999B93A1E1E87A7BEBB749EFF236E9F3F40BE923B721EE9378CDF09895F79A42F6DE6BCEC16BDEC49BBDC9D086F46EA59DD45C7FFE698AA32523BA3BD30D6E7548EE2754C3C5BB61EF86F7D30DD30D8FDE133BD9776AB3C39E0B8BFDDC56C5C2DD265DB1058D63CEEF38B87FA09392A41785C66291FA83F576DD2770FD1DA75F50B8D50C718C953B5D05D9A77808CED7F51BEDAEDD5879BCBCE865427342B8FC8AD2607982B6293E09519A06778178D6A7AFB4AE4E52D12DAFFDCEEAB8CB546AA7925F3D92CBD3AFEBF3DCFAC839C87122FAB6B5DF2BE7B32CAD59F62CCBAAFBE59E645BD3EC9DD3B5D0B859A1EFBFCFA8FFDEA0FB8F685F26FA450ABA493FFA9FAB1659DE8D6C0523BF73C0F778708FDF93EE9E6B324C93FB9EB0AF3DE1A2D513AE70986B55FFE9E3E0A87190B17E3FF93866FE9669EF049427C4F7A4ABEFDCDE96F25EAACBBB77E829ED33EBED67C7BC73999B73F95C9D18ACC3D0078CF245A7FDF034A0551B8B8D1BFA651B9078CDBA8D6B044D914DEDF3FA809FBBD4B0F7DE55E85DE9FDF47BE250A7596BF8F3EB013BACCD8DFED3BF9CE09DC61E3B0DEF31F6CD63F8EEBABFDD95A6C8A75FB7C1668F2E42BD0AD8D5BE1E53A7D3DE768A36B471AC046951F71264E60F0DEDE8E8CC7B57955976DBBBEE9B539D78F2DBE72EBE77897297FC91E9F32825DC967B741065AF3218A689ACC4E178F86CC66733DEDF8EE66FF7D3CDDE0459A84E6A5EFFF89331D7969D000F43D9A44DFE614EDF8B6D7AF1C936CCB6093EF7B3B4DAE4A9B29455EA54D3F65B28A9B84477B15A41F34D00DA2332C62C852757EDEEF9F3EE67DFDD8F773D1EFEFB027FFBB1E58FAF5E1B5B81D8E03E4ED446F849B38F07DC61AF82FBF63CC0719AE2348D27D861B78D82AF5B1C14FDF42EC8D3E901A65BC413267CD5801480E3D667E3D9797A811195C7E6DE82DF529CF49B4CBA8A35A3A457E68324EFE85466999FA3B3751B7BEA2EA87EBF15B5EDE43CC5A07B436BFB0CD503FF1ADF4A9D1A44C0FA82E19E9ED1C13CFDB2D73CFDD2D53CFDB7A86F98B826726E538340018B7FC7DB2CBE266AAEB621EE1508AF304A87B809C90732B959F627904DF656F4DEA6BFC60B995513F45BCFA44C7A9D5A055C436575BD957726CFC2994C776FA6F726733C5E26F1275633E89FE2E328FD8613CE5BF2F6F76376EF9D14DEA9C4D133F051BC2B70E1AB5CDDE391AC8208857D46667E79CEBB003B17F07C463DF3F601F2A61978EAB1AA25EF916C6FB4E5A59EC87CF983CDB1BA8271D3FD6C9CA4776DCFCBB59D051109AC13DCCF37826B13CE7472011FD82DE89521FDA6872B7B3BF12415AF9C8BF9F0AD43DCCB2D579CAEB7B7BD24A1F4FD368CA10DEABD9AB1331111B0D8D03D4B0D5B6CB8C21BE2EEFAAC321CA769701FE155FF65F7B3805FF4B34ADAAFF06380BFE53EDCC15E80D6DA6705DFF3287757281C3A13F1F1596196FD8BCFCC3CD61CE234C0DBB16E6D06A3965D1B6BB81F1F1427AA9C0C124EA3959BC1469C24803BDE586D61418CB44B7160E7789B3DC4247D7B3AFD8E13E2BAFA2D9FFF8ED263523A8B2BD9CF8919560169F9F0A90FDBD3C71CAB4B9C473B02A107D79B26FD693A217B1FEE6612EEBEE0A4F4D333886F7BB21438E9435245F27F19B11DCA948F8B53C4820192D5F8C1EF20F60E72440799A72E7761FC2D3F478B4866B08F9E31FFBFF3C343D470C613510D651F9F5A73C95D8FC56C1843EE42929B04456960B7CB43C4A3D794558D67BF23C3FB40A80F6CC0E74F4D2A9A25DE264BDCD3FD0899F4EAF037714F9138067D7CE215FEBA0D12D28638590769AA9B7AD09D23F4CEE8D939A30284DE0F299A3A8E32FCDDFDA0D2F7AC3DEF59BE53C9997E447FC4BD66423E06513F0674CAE9023DC55B7615C4747D7899058FD44A962BCC787D1B1AA11E96AF1076CE990E79CAB4B02501EADFD09AEE8F2D1DB0F7AFFBEC5F35530F8B9E730FDC22AE535F5F83D6FBFC699C46DE0E3D66A87670760AB84C4ABC932E00FC68CAB611CF3D6FEFB55566999FD7B65E0098CE63EEFA420060C6D9647580B2EB352DC606427BE7D770E825503E33868B95F85BD77DC670D2CD627F0BF973BDC9CEE2E4338E37CD2AABDD0519851DB49EDA7C636DC5F9AFBAFB37ECF50FC2AC592FB751DE4713955976389A5CA20DBB75A4F61FE91C228AC5A652FB6D38174EB7E15C989EC8376AB4E3CD26891F51D8E49013B41734240D6886E24041BE5969FF0C316838134506837D50468D7492E745845731D2D9BB663232C5E7ED2DF1B10FCFDC0A5778898347FCECADF047B9CBFD99DB21DF15FA7C4C402256BC0C8A2A2A415A472E17D56947D608A7D1EA20DF26DA295C8B7F8DC3BB179DDF3F6EC32CD884C192D4FFF6F0E58B17AF38F3701CAB9A454CE9A72EDF7FE398564F6F64010A4FE2FCA10F444CCBB75E102D830D0A051A3165816D9D1B9B7265BFBCC31B1CE5499C585D488DCC815ABE725A0703419D3DDE1CB5D0A00689E096B6CE554B52C0740AB51BB7FBA1DBB4AF58BBBCB98CDEE11067F8E0B87059F989DA7489567C9E4160BF82C8C2EC31E744A2DF07019DDC74C3A04E7B59A2A45AF684C0E4D8CB417796E43316D1F289EF41DDC6EE16645A9AF9383A00C19DC11DE414861B1E7650BC75849C0DE688A859BC8C4332F859EB60C795655A9AFFFE1CC0A7B6E07CF0C7CA390B08969B5B162771B85D7329AAB8894B126943D79F47875E5971A98946BABAD0E021B832C6C888EC2809A95BB0D7692A647E087092CFD63C2D944674894DCD38A22D14CBB9F561BFB0D428B6C3F809C215615CFF1228469F566D6C809B9CD704D8316B4587A829F485D4F919E57A51BA59C4C43C2D130EA38707CC9479D4D860314EA05A376ECD0223EE01B29F09FAEC81351B54BD4FE2ED66B7A7BF0A15A402555FF76EEAABD46B2727BE28E6DE2768F3102C5588AB8B30CD4B7FB60E7793A246A8F8CC3053C9380BC4DCC49B60B9D0A8E2AEA10D60544826E55E7D1DDCF9C01BD6219A4AE54C3D5021EA2C40555F3A277C67E31DCA902EDB9213C9F0C017B4061E7DDA4557D708F0531B6D78248A9FB9018091157C56B8BC41F71FD146884EF2C9089879791D4E8A32A3276F5D65214216C546833467E9F1D05CE96A8B69423E2B38CB804C7484AD02587B3C0F6398679C1F862707F0454B982B1CE65BD4EB3F59DFCC7C1E16D2C044412DBEB0561DC95E4256A3B4297C191693A358EA86795D77DB157BBC4F82F7D9029D6EC0016DAD926EABDAED619AC408C322CC665846059D178EEA5D34F50F1F305A71F7288F1EDF255249F667B1A5F6CDAB41DA480EBC793AB272D2B3160916982DA623471C1DCD61AE0A3E6B398709AA42DA59A0F17A7B5BAEDB1422C1D058D348DBBD29303A26E731714F0DB01373F7B5B4B3006489C65A2418202DD6824680A27537D9979524A35E30ABC5A4FC8EBCFCD517F41145E81E736789065DA61C0E9A02B558D18445F60A9E220D770EA0A46B5D3FA5195E175B0C8B7FA9E0589560DABAFE752CF851A139419A0F43414D64A3C120D6E8030456597A861E4FA249DF76D58F83E7E6AACC9A74522F45459D239E76C455CD0E7EBB82BDC9814763F4E9D76DB0D9FD53E0540DA950AD127BB71DB6D1CD34459B1F0625BA74DB5DDADCD2567E2E183483C29418A404B3C0607E5B5D7EF566B25D720BC53BE70D1965A4A271E5F6CE33B21AEEA47F146053A95717151A306830F01CD16A039AE931CB904D8A5CD230DB049F57332FD59F4A375A1561DBBEFE79345036924B64391F74024668AAE120D75209EA192B92A9D0C55C329B5FDC8949A144BE04C250749A95FB663401C350D7A2A86A68CA0C8220569F116024531052B5E0E9EA39804A742F9AF0B22DB7579299A14D5489ACC8E0699DC955646EF1667B095A453717C82D2A790671630385CBB901727AE76702C699FABEDD1BF8F6E8183B3AC0B5013A2158CE0D6B7493E971947EC3F0144EB8A34E5A660A10D6B5978A41E4AC4B8EE119C7DC9EAA56D7C2514EBE4B550662D308BE3B28064476AEE833C1718F883F572057B7542F54175CBBB8F67B5C0C57B240304C8B0E794DB9C9BDE1C340B75613224157E89923160257937BEF9F3750770FA57384688DCD3DCC0E6603D8F9650726E0DD91EC60F1292E7377DD84A8533C8367456B16AC94805A3912C0ECEC9EE054D9A646924C084CBD4D473EA7EAB007ECF819D53E889FB353049C4F9DFDB4FD0C6039FDC4BD1122E73A73FF0527F903A3F933B203A0D1CCD955B228A73E9B327B8A2AAAE02EA1AA7EB6F73A43195EC8DFD36B9ABE43D16970E6CB28EEADAEB3915C2852FBF320F0EBEA3E02F8049A416ABD8EB7C91277A49D1C7B8D0A8B9B5861C8FE20D478350F26333031AD3539901673008F90E1BE0105545737B64C8E8E3CCC3C12EBCF0225B53042C6CDC7FD420DD50B8A9E79B8150E383237E93294EC108E0CA3C65460EA8A3A39AAF2CDFBF90BF71CBAC48AB96AFB81F370562BA16C7CA141F169841447E8E4543441694D341B8C2EC6F07823215389C8BDF49454B91DF794D4436A3108CAC18111760EB8993D5AE687912993FB394066F4E4DE0A37F348F0A5A9985827572DFE0C53312390CC2115AB89E7B2EC43A7BAF2B66C782FCE9278CDC1767113E7EBE40B090FFD1CBF25AC959758C9A56116E4150587DAAB31054CE10D6454FF84D06CFD7EA13A5634BFC5F241E0B9BB0B9CBDA1C9206132A41E6F3649FC88C2F64A93C27F7616A40A0FCA33D03BCF1E0361B5031509C38253586668B739EEF016D42E46558F81C4340DEEA37CDB9D3D16052CA644A3501C0E8FE2527B88487DEBCC0D932779AA1386C54FD6A81433991097328158644ACBED1F36416D3437747EDEDE92C4E3C11A981CFD849814C8C2C2515464FF90A86B94B981F00A2F71F088AD41C8D14F0842812CDCD0465064FF40A86B94F981F00FBCEC15A4051C2605A2401A1E8AA242FB08465DD3CC0D8ED724CFB5466297784210B282B0F8E3BEEF1FF4946D312DEA4E094DF64468324281937AC012AFF05990A4C57DECB728E5D76772AA6B9C09CFB31F1E94DF1557175C2F1FF01ABD3D5CDDC60410E8B6B654B75C2A8096B06275ADA02A61F55D4A6EE0E7AA96159449212E0F12884E1D56EFFA886461CB28C4E8163593405339AC5EB32AE9F15265CDB41444007AF30C400EFACCA804827C1185049D92A0EAEBA72ACFE2642D97802FA510822D0C92E3438013942C1F9EC402B43E2B6AA6A5CC1070819EE2AD0E00752148FB97656D843889C3ED3A02895217850B545280C47A9FA0CD43FEE6A04810FA51517555C6CC06CDCB724AFD9B6210DD9B37F94C44A99E5C54CA51958108513D5369224173C6532944530C2247733ED646943CB6C89D84A2B8896835959D8837E8BE78281D24605DD844BC92C65A38B864C662C165BA68118A5E99978AA823D449ACA6378B979A58098B934631927DB65A1529D9B28078D9250149D67AA94C244CEBB3A27E5A0A56A5AA3E4065F09A28C65BAFB4283B4FAB1CA4EBD0E220693442C0EA36ABB2B3A4DF7968416906AE34C4180C11483E905826D2D808D17905406897760195299A7226152B2B8554A8AF4C7A653D57B3B4A44C0C0981B14C7A59C03218D72D1FC0C90A0225010FE3A4B773E824D2276F12026B99EA6B6DA192D5E50DE5AB2F10B69412DCA41C81A19C7D9B985EA006159412180A4AAFABB31494BB4C0B2A3047682838436FAC407329894EE2A62450C49A402F13BFA19613862F2293822D09AFBE3D872E15A05D48274267DA1C284475EC425A7FF55D5775510C5EABA2427D5DF06A9A4DF6D2EA9A22BA6AEB92E6F80288C11785E20D2E96A0CFB44C2ACA7B14C5819D12DE6697B24D9442C184256532090B43C411EFA1130B242E2B15495C1C209474FB94502C6969996052028068A2AD3442A94405650289CA42802ED8512186B8A0A014DC82B22059444BEA12694445E5F2884A0324E2165985C270A56472700519115A8B8DC2B5BA45B3C0D72ACAAFDA35E5D89550C90DD45477E6776E25557EE13ACF827E620F3A74D5049840303CE93E102330879646AE9A68885728D6FDA0308E62A0C631A2DF9D9A895B17D3D9882750AA275CC0AB75633E020D0536B503D3F04B7B7AEB70344AB5644B8CB576FCF79999A95C3D5BD0E533B58198D23055BA4B909C42F567A061446B89129E75211706A3CBAF0B4E70A1C9E4E547341AB7F05CF3697D706D9C205C2538AA7F09C4514C4BE3582D29875C9A818DD3F12E345AEA1D91E4D10ED7A698C431436DB097062856EC8D321B01C558794D67CF02C7A6FA3A8C79E8560CA071EAF24AC598CD1FB546F4E7D99AA5D865C16F41D359474636989A525E9D5D271CAFEAAB5393296FEB6F3670A80D08630233816CAF09670DBE20D0C8ECF28C94F340A62E7790C87671406DADE162668AD6C614A9358A328626EEEEC651B12E8A8D876CBA8BA707B06B1E03A36EB646566FE6E9988CF9AC327B0FAE5334046C2B55A70E1DC9F0BD40B8F5CAA22788F8F8465037426B831ADCE20D116C2A4A3A0DB533417221DB4807349A847C6474AA770EB213606CA90172E3D6FE11484E2C794EC765FE3A3B04D6FBC517F59E6DB5A1D8E230E5D89DEE9C724D81D90E1D4AB55BDBEB2163D0A6F8F8A32B6BA3DB194A701C0B3C3685D18E6642C591B59AA1B0880B33D2EDC9CDF66189D14425956A75F732D79AD4BFAA4DC26DBDA6E4CD870151D4AAC504400D9963E5E6841899EE36F61A1845539A89BA00BA2BDD68C2554235D6A42BB71F9F63D52A319CB95A951898ABA1522A2BD551AADA0CCDC56CEA37C29892762CA4498E39700CB972439B91ABD0D8982C07A5413476D0A83F53F336873E5A47326496141756ABD93D2542B5AA7FD618893FDCC27038779368B04F57B60E82F0A69017962B23392F5268C37D531845731646C4AF29E3DA4CA2DD54741393D66E2AEA413754A90C2A62292BE21C75CD19013DE868D9D13137A98974D153597EC888D9C3D8FDCD42A7FDE8B923AD653812B06AC289296919B8C9C447B454DCEB928399D3A043F234B33128A0C37245873269B52378C1EE0C06DB57C2406E14EBEDC910D332E7DF54A6A54547326D3FBBC28C6ABD677C07CCB9688E1CC23B3FA5994DE79F9549B9C39470CBB2A4B331B0E464A9AA1A8E6430838B95845B5D483FE622A2C3C674907D2A970FE585474FD127365375B078F5AB70915F517A7443B1A7AB45FC9A32BD0DD539FCBBE81C00E3ED242F2C574F7848B9508AF9A23091FCB4758751FBB333C374AE616544965B4841B5BFA65A80CDA37A7170309308C91DAA2F792B5D6106C8EBEA8399833DD1DE61D37C1CCE3C6D0C1AD8487ED7AFCB6E300B93E99FBB5618CEF0AD6C770A0B39C9EE51E870E40B3937E502863AED23CE23A08DBDDA4468AA214CD4F84680816861470E789EA6D0BA72C85BBA83B9F2A9CC237FFBD5C62FC91E9074A5F0ACFCD2A04F94EA87386EEB1BA3C1D40A7707F4F01B6CDC351CFB80A7411B28DFFE1C64CC3917630EF2C6A4C0F2C3BF6539603E20D5936927C81549164D34D4E38BA2661AE5A1C7A19B4A75E354D358A0CBA3CC9B6BD07709054D36DE3B8803379BE64E2EDA70D0CBB5CC9B6E8047FB040D36F4D380033793FC7E32DA4280DBC62CC2BEFBC7EC4419C2C04FE60DDC38F20BDB9A64427FFD9A4DE30CF2C89BB081867F4E6EF04692DF64D76A26C0AD74E60DE5F4F93341F30CF7BCDAC08D22B9CC8FB687EE763E7953BC392A59D1F7C0E8B73747E55D80D50FE4CF2C4ED03DFE18AF709816BFBE39BADA12EA352EFF7A87F3A485B278437846254C1AA67599F3E82EAE9F406324AA8BD49F2B707CC4195AA10C1D275970879619F9BCC4244DCAD7FFBFA0704B8A9CAE6FF1EA3CBADC669B6DB18B747D1B7646E3F9736AAAFADF1C7132BFB9DC143675A1021133202AE0CBE8D76D10AEA8DC67284C99E1AD8C45FE4EDB7B4C7E2FDB924037C3F74F94D3A7380232AACC479F97BBC1EB4D7EAA3ABD8CAED123B691EDB7145FE07BB47C22BF3F06C5895819137D4374CDFEE65D80EE13B44E2B1E0D3DF9936078B5FEFE1FFF1F10B6B40484080500 , N'6.2.0-61023')

END