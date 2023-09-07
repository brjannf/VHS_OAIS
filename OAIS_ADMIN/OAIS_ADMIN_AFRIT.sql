DROP DATABASE IF EXISTS `db_oais_admin_afrit`;
CREATE DATABASE `db_oais_admin_afrit` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;


DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_isdiah_vörslustofnanir`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_isdiah_vörslustofnanir` (
  `id` int NOT NULL AUTO_INCREMENT COMMENT '5.1.1 Identifier. Einkvæmt númer (hlaupandi)',
  `5_1_1_auðkenni` varchar(10) NOT NULL COMMENT 'Skammstöfun fyrir heiti skjalavörslustofnunarinnar.',
  `5_1_2_opinbert_heiti` varchar(100) NOT NULL COMMENT '5.1.2 Authorised form(s) of name. Opinbert/formlegt heiti skjalavörslustofnunarinnar.',
  `5_1_3_erlent_heiti` varchar(100) DEFAULT NULL COMMENT '5.1.3 Parallel form(s) of name. Heiti skjalavörslustofnunarinnar á ensku eða öðru tungumáli.',
  `5_1_4_annað_heiti` varchar(500) DEFAULT NULL COMMENT '5.1.4 Other form(s) of name. Önnur/eldri heiti skjalavörslustofnunar, eða upphafsstafir.',
  `5_1_5_tegund` enum('Þjóðskjalasafn','Héraðsskjalasafn','Borgarskjalasafn') NOT NULL DEFAULT 'Héraðsskjalasafn' COMMENT '5.1.5 Type of institution with archival holdings. Tilgreinir um hverskyns stofnun er að ræða - Þjóðskjalasafn, héraðsskjalasafn o.s.frv.',
  `5_2_1_aðsetur` varchar(500) DEFAULT NULL COMMENT '5.2.1 Location and address(es). Veitir upplýsingar um heimilisfang og staðsetningu.',
  `5_2_2_samskiptaleiðir` varchar(2000) DEFAULT NULL COMMENT '5.2.2 Telephone, fax, email. Gefur upp upplýsingar um aðgang símleiðis eða gegnum netið. Veitir nauðsynlegar upplýsingar um hvernig hægt er að hafa samband við stofnunina.',
  `5_2_3_samskiptaaðilar` varchar(4000) DEFAULT NULL COMMENT '5.2.3 Contact persons. Listi yfir forstöðumenn og starfsfólk (nöfn og netföng). Veitir nauðsynlegar upplýsingar um hvernir hægt er að hafa samband við starfsfólk.',
  `5_3_1_saga_stofnunar` varchar(4000) DEFAULT '' COMMENT '5.3.1 History of the institution with archival holdings. Saga skjalavörslustofnunarinnar - Stofnun, breytingar á heitum, breytt hlutverk o.s.frv.',
  `5_3_2_landfræðilegt_samhengi` varchar(4000) DEFAULT NULL COMMENT '5.3.2 Geographical and cultural context Upplýsir um stöðu skjalavörslustofnunar í landfræðilegu og menningarlegu tilliti. ',
  `5_3_3_stjórnsýsluheimildir` varchar(4000) DEFAULT NULL COMMENT '5.3.3 Mandates/Sources of authority. Veitir upplýsingar um lög og reglugerðir um starfsemi skjalavörslustofnunarinnar.',
  `5_3_4_stjórnsýsluleg_staða` varchar(4000) DEFAULT NULL COMMENT '5.3.4 Administrative structure. Tilgreinir stöðu skjalavörslustofnunar innan stjórnsýslunnar og hvaða stofnanir heyra undir hana.',
  `5_3_5_varðveislustefna` varchar(4000) DEFAULT NULL COMMENT '5.3.5 Records management and collecting policies. Veitir upplýsingar um skjalavörslu og aðfangastefnu skjalavörslustofnunarinnar.',
  `5_3_6_byggingar` varchar(2000) DEFAULT NULL COMMENT '5.3.6 Building(s). Veitir upplýsingar um byggingar skjalavörslustofnunar.',
  `5_3_7_skjalaforði` varchar(4000) DEFAULT NULL COMMENT '5.3.7 Archival and other holdings. Veitir upplýsingar um skjalaforða skjalavörslustofnunar, aldur, magn, gerð, o.s.frv.',
  `5_3_8_útgáfur` varchar(4000) DEFAULT NULL COMMENT '5.3.8 Finding aids, guides and publications. Veitir yfirlit yfir heimildir og handbækur sem veita upplýsingar um starfsemi og fyrirmæli skjalavörslustofnunarinnar. Bæði birt og óbirt efni.',
  `5_4_1_opnunartímar` varchar(500) DEFAULT NULL COMMENT '5.4.1 Opening times. Veitir upplýsingar um opnunartíma skjalavörslustofnunarinnar og þjónustueiningar innan hennar.',
  `5_4_2_aðgangsforsendur` varchar(2000) DEFAULT NULL COMMENT '5.4.2 Conditions and requirements for access and use. Veitir upplýsingar um aðgang að skjölum í vörslu skjalavörslustofnunar og um reglur um takmörkun eða sérstök skilyrði varðandi aðgang að skjölum.',
  `5_4_3_aðgengi` varchar(2000) DEFAULT NULL COMMENT '5.4.3 Accessibility. Veitir upplýsingar um hversu aðgengileg vörslustofnunin er , þ.e. um staðsetningu (hér hægt að tengja við kort), tengsl við almenningssamgöngur, bílastæði fyrir gesti, aðgengi fyrir fatlaðra o.s.frv. ',
  `5_5_1_rannsóknarþjónusta` varchar(2000) DEFAULT NULL COMMENT '5.5.1 Research services. Veitir upplýsingar um þjónustu skjalavörslustofnunar við þá sem sinna rannsóknum.  ',
  `5_5_2_afritunarþjónusta` varchar(2000) DEFAULT NULL COMMENT '5.5.2 Reproduction services. Tilgreinir reglur skjalavörslustofnunar um afritun gagna í hennar vörslu.',
  `5_5_3_almenningssvæði` varchar(2000) DEFAULT NULL COMMENT '5.5.3 Public areas. Veitir upplýsingar um aðstöðu fyrir almenning, t.d. varðandi sýningarrými, kaffiteríu, internetþjónustu, sjálfsala, verslanir o.s.frv.',
  `5_6_1_lýsandi_auðkenni` varchar(45) DEFAULT NULL COMMENT '5.6.1 Description identifier. Sýna auðkenni lands og skjalavörslustofnunar, skv. ISO 3166 og ISO 3166-1 stöðlunum, sem skilgreina tveggja og þriggja stafa kóða auk kenninúmers fyrir lönd og pólitískt afmörkuð svæði.  (Auðkenni lands - Auðkenni stofnunar).',
  `5_6_2_einkennandi_heiti` varchar(200) DEFAULT NULL COMMENT '5.6.2 Institution identifier. Gefur upp fullt heiti skjalavörslustofnunarinnar sem er ábyrg fyrir skránni og gerð hennar.',
  `5_6_3_reglur_staðlar` varchar(2000) DEFAULT NULL COMMENT '5.6.3 Rules and/or conventions used. Veitir upplýsingar um heiti á reglum eða staðli sem unnið er samkvæmt.',
  `5_6_4_skráningarstaða` enum('Drög að lýsingu','Lýsing í vinnslu','Lýsingu lokið','Í endurskoðun') NOT NULL DEFAULT 'Drög að lýsingu' COMMENT '5.6.4 Status. Veitir upplýsingar um vinnslustig lýsingarinnar svo notandinn geti gert sér ljóst hvort skráin innihaldi allar upplýsingar eða ekki. Vinnslustig innihalda: Drög að lýsingu, Lýsing í vinnslu, Lýsingu lokið, Í endurskoðun.',
  `5_6_5_skráningarstig` enum('Lágmarks skráning','Skráð að  hluta','Full skráning') NOT NULL DEFAULT 'Skráð að  hluta' COMMENT '5.6.5 Level of detail. Veitir upplýsingar um stöðu skráningar.  Skráningarþrep eru þrjú: Lágmarksskráning, Skráð að hluta, Full skráning',
  `5_6_6_dagsetningar` varchar(2000) DEFAULT NULL COMMENT '5.6.6 Dates of creation, revision or deletion. Gefur upp hvenær lýsingin var búin til, breytt eða eytt.',
  `5_6_7_tungumál_letur` varchar(200) DEFAULT 'isl' COMMENT '5.6.7 Language(s) and script(s). Veitir upplýsingar um á hvaða tungumáli lýsingin er, skv. tungumálakóða staðalsins ISO 639-2.',
  `5_6_8_heimildir` varchar(4000) DEFAULT NULL COMMENT '5.6.8 Sources. Tilgreinir heimildir sem byggt er á.',
  `5_6_9_athugasemdir` varchar(4000) DEFAULT NULL COMMENT '5.6.9 Maintenance notes. Notað til að halda utan um skrána og þær breytingar sem gerðar eru á henni.',
  `hver_skráði` char(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dags_skráð` varchar (100) NOT NULL,
  `hver_breytti` char(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `dags_breytt` varchar (100),
  `klasar` enum('Austur','Norðaustur','Norðvestur','Suður','Suðvestur','Vestur- og Vestfirðir') CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_vörslustofnanir_notendur1` (`hver_skráði`),
  KEY `FK_vörslustofnanir_notendur2` (`hver_breytti`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_isaar_skjalamyndarar`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_isaar_skjalamyndarar` (
  `id` int NOT NULL AUTO_INCREMENT,
  `opinbert_auðkenni` varchar(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL COMMENT 'Hér eru skráðar þær upplýsingar sem notaðar eru sem opinbert auðkenni skjalamyndara. T.d. kennitala fyrirtækis eða einstaklings, fjárlaganúmer opinberrar stofnunar eða annað, o.s.frv.',
  `5_1_1_gerð` enum('Stofnun/fyrirtæki','Einstaklingur','Fjölskylda') NOT NULL COMMENT '5.1.1 Type of entity. Segir til um af hvaða tagi skjalamyndari er (opinber stofnun, einkafyrirtæki, einstaklingur, fjölskylda, félagasamtök o.s.frv.).',
  `5_1_2_opinbert_heiti` varchar(500) DEFAULT NULL COMMENT '5_1_2 Authorized form(s) of name Gefur upp núverandi opinbert heiti stofnunar/félags/samtaka eða skírnarnafn einstaklings.',
  `5_1_3_erlent_heiti` varchar(500) DEFAULT NULL COMMENT 'Gefur upp opinbert heiti stofnunar/skjalamyndara á erlendu máli/ensku.',
  `5_1_4_annað_heiti_aðlagað` varchar(500) DEFAULT NULL COMMENT '5.1.4 Parallel forms of name Gefur upp annað/önnur heiti (ef til eru) yfir skjalamyndara, sem orðið hafa til vegna ákveðinna reglna eða hefða.',
  `5_1_5_annað_heiti` varchar(500) DEFAULT NULL COMMENT '5.1.5 Other forms of name. Gefur upp heiti stofnunar/embættis/samtaka í fyrri tíð eða nöfn einstaklinga áður, hafi þeim verið breytt.',
  `5_1_6_auðkenni` varchar(50) NOT NULL COMMENT '5.1.6 Identifiers for corporate bodies. Tilgreinir þá tölu og/eða bókstafi sem vörslustofnun notar sem auðkenni skjalamyndara.',
  `5_2_1_tímabil` varchar(21) DEFAULT NULL COMMENT '5.2.1 Dates of existence. Gefur upp stofnár stofnunar/samtaka/félags (og lokaár ef á við) eða fæðingardag einstaklings.',
  `5_2_2_saga` varchar(10000) DEFAULT NULL COMMENT '5.2.2 History. Veitir yfirlit yfir sögu skjalamyndara. Ath. Upplýsingar í töluliðum 5.2.3.-5.2.8. má færa inn fyrir hvern lið fyrir sig og/eða sem heildartexta í lið 5.2.2.',
  `5_2_3_staðsetning` varchar(500) DEFAULT NULL COMMENT '5.2.3 Places. Gefur upp hvar skjalamyndari er/var staðsettur, hefur/hafði yfirráð eða önnur tengsl, þ.e. land/svæði/borg o.s.frv.',
  `5_2_4_lagaleg_staða` varchar(500) DEFAULT NULL COMMENT '5.2.4 Legal Status. Gefur upplýsingar um lagalega stöðu/lagalegt hlutverk skjalamyndara.',
  `5_2_5_hlutverk` varchar(1000) DEFAULT NULL COMMENT '5.2.5 Functions, occupations and activities. Veitir upplýsingar um hlutverk og starfsemi stofnunar eða stöðu/starf einstaklings',
  `5_2_6_tilheyrandi_lög` varchar(1000) DEFAULT NULL COMMENT '5.2.6 Mandates/Sources of authority. Tilgreinir undir hvaða lögum og reglugerðum stofnun/fyrirtæki starfar. (Hér má rekja öll lög sem hafa verið sett um starfsemi skjalamyndara, allt frá upphafi).',
  `5_2_7_innri_stjórnun` varchar(2000) DEFAULT NULL COMMENT '5.2.7 Internal structures/Genealogy. Lýsir innri stjórnsýslu stofnunar eða veitir upplýsingar um ættir ef um einstakling er að ræða.',
  `5_2_8_almennt_samhengi` varchar(1000) DEFAULT NULL COMMENT '5.2.8 General context. Setur skjalamyndara í almennt samhengi við það umhverfi sem hann starfaði/lifði í (félagslegt, menningarlegt, efnhagslegt, pólitískt og/eða sögulegt). ',
  `5_4_1_auðkenni_lands` varchar(100) DEFAULT NULL COMMENT '5.4.1 Authority record identifier Tilgreinir auðkenni þess lands sem skjalamyndarinn tilheyrir.',
  `5_4_2_auðkenni_vörslustofnunar` varchar(100) DEFAULT NULL COMMENT '5.4.2 Institution identifiers. Tilgreinir auðkenni vörslustofnunar sem geymir skjöl skjalamyndara.',
  `5_4_3_reglur_staðlar` varchar(500) DEFAULT NULL COMMENT '5.4.3 Rules and/or conventions. Gefur upp þær reglur/venjur sem skráin byggir á.',
  `5_4_4_skráningarstaða` enum('Drög að lýsingu','Lýsing í vinnslu','Lýsingu lokið','Í endurskoðun') NOT NULL DEFAULT 'Drög að lýsingu' COMMENT '5.4.4 Status. Gefur til kynna stöðu lýsingarinnar; hvort hún sé tilbúin, drag að lýsingu, í vinnslu eða í endurskoðun.',
  `5_4_5_skráningarstig` enum('Lágmarks skráning','Skráð að hluta','Full skráning') NOT NULL DEFAULT 'Lágmarks skráning' COMMENT '5.4.5 Level of detail. Gefur til kynna stöðu lýsingarinnar (skráningarinnar); hvort hún sé tilbúin, í vinnslu eða í endurskoðun.',
  `5_4_6_dagsetningar` varchar(1000) DEFAULT NULL COMMENT '5.4.6 Dates of creation, revision or deletion. Gefur til kynna hvenær skráin var búin til, endurskoðuð eða eytt.',
  `5_4_7_tungumál` varchar(100) DEFAULT NULL COMMENT '5.4.7 Language(s) and script(s). Veitir upplýsingar um á hvaða tungumáli skráin er, skv. tungumálakóða staðalsins ISO 639-2.',
  `5_4_8_heimildir` varchar(2000) DEFAULT NULL COMMENT '5.4.8 Sources. Gefur upplýsingar um hvaða heimildir voru notaðar til upplýsingasöfnunar við gerð skráarinnar.',
  `5_4_9_athugasemdir` varchar(2000) DEFAULT NULL COMMENT '5.4.9 Maintenance notes. Notað til að halda utan um skrána og þær breytingar sem gerðar eru á henni.',
  `hver_skráði` char(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dags_skráð` varchar (100) NOT NULL,
  `hver_breytti` char(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `dags_breytt` varchar (100),
  PRIMARY KEY (`id`),
  UNIQUE KEY `auðkenni_unique` (`5_1_6_auðkenni`),
  UNIQUE KEY `uniq_heiti` (`5_1_2_opinbert_heiti`),
  KEY `FK_skjalamyndarar_notendur1` (`hver_skráði`),
  KEY `FK_skjalamyndarar_notendur2` (`hver_breytti`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_isadg_skráningar`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_isadg_skráningar` (
  `id` int NOT NULL AUTO_INCREMENT,
  `vörslustofnun` char(4) NOT NULL,
  `skjalamyndari` int DEFAULT '0',
  `tilheyrir_skráningu` int DEFAULT '0',
  `ritskoðun` enum('læst','ritskoðað','opið') DEFAULT 'læst',
  `3_1_1_auðkenni` varchar(100) NOT NULL COMMENT '3.1.1 Reference code(s). Samansett af landi, vörslustofnun, auðkennisnúmeri skjalamyndara, auðkenni afhendingar (afh.ár og afh.nr.), skjalaflokki, kassa og örk.',
  `3_1_2_titill` varchar(1000) DEFAULT NULL COMMENT '3.1.2 Title. Tilgreinir titill skjalasafns.',
  `3_1_3_tímabil` char(21) DEFAULT NULL COMMENT '3.1.3 Date(s). Tímabilið sem skjölin ná yfir.',
  `3_1_4_upplýsingastig` enum('Skjalasafn','Yfirskjalaflokkur','Skjalaflokkur','Kassi','Örk','Skjal') NOT NULL COMMENT '3.1.4 Level of description. Skráir lagskiptingu skráningarinnar, þ.e. hve "djúp" skráningin er. Efsta lag er afhending og koma þar undir yfirkjalaflokkar, skjalaflokkar, kassar, arkir (og skjal).',
  `3_1_5_magn_lýsing` varchar(1000) DEFAULT '' COMMENT '3.1.5 Extent and medium of the unit of description (quantity, bulk, or size). Lýsing á magni og tegund innihaldsins - Gefur hugmynd um hversu stórt safnið er og tegund innihaldsins, s.s. pappír, spólur, filmur o.s.frv.',
  `3_2_1_heiti_skjalamyndara` varchar(500) DEFAULT NULL COMMENT '3.2.1 Name of creator(s). Heiti á skjalamyndara.',
  `3_2_2_saga_skjalamyndara` varchar(1000) DEFAULT '' COMMENT '3.2.2 Administrative / Biographical history. Stutt yfirlit yfir sögu skjalamyndara.',
  `3_2_3_saga_skjalanna` varchar(2000) DEFAULT NULL COMMENT '3.2.3 Archival history. Veitir upplýsingar um sögu skjalanna: Um tilurð/myndun, eigendur þeirra/skjalamyndara og tilfærslur milli skjalamyndara ef við á. Tiltekur einnig ef saga skjalanna er óþekkt.',
  `3_2_4_afhendingar_tilfærslur` varchar(1000) DEFAULT NULL COMMENT '3.2.4 Immediate source of acquisition or transfer. Gefur upplýsingar um flutning á skjalasafninu frá skjalamyndara til vörslustofnunar, hvenær og hver afhendir.',
  `3_3_1_yfirlit_innihald` varchar(11000) DEFAULT NULL COMMENT '3.3.1 Scope and content. Lýsir umfangi og innihaldi skjalasafnsins.',
  `3_3_2_tímaáætlanir` varchar(1000) DEFAULT NULL COMMENT '3.3.2 Appraisal, destruction and scheduling information. Veitir uppýsingar um mat, eyðingu og tímaáætlanir - Gefur upplýsingar um áætlanir um safnið.',
  `3_3_3_fyrirsjáanlegar_viðbætur` varchar(1000) DEFAULT NULL COMMENT '3.3.3 Accruals. Veitir upplýsingar um hvort viðbætur við skjalasafnið séu fyrirsjáanlega væntanlegar til afhendingar á vörslustofnun.',
  `3_3_4_innri_skipan` varchar(2000) DEFAULT NULL COMMENT '3.3.4 System of arrangement. Veitir upplýsingar um skipan skjalasafnsins, þ.e. röðun þess í skjalaflokka.',
  `3_4_1_skilyrði_aðgengi` enum('Vegna laga','Vegna samnings','') DEFAULT NULL COMMENT '3.4.1 Conditions governing access. Veitir upplýsingar um hvaða lög eða aðrar reglur takmarka aðgang að skjalasafninu.',
  `3_4_2_skilyrði_endurprentun` varchar(1000) DEFAULT NULL COMMENT '3.4.2 Conditions governing reproduction. Veitir upplýsingar um hvort hömlur eru á eftirritun/afritun skjalanna. Tilgreinir hvort höfundarréttur eða birtingar-/útgáfuréttur kemur við sögu.',
  `3_4_3_tungumál` varchar(100) DEFAULT NULL COMMENT '3.4.3 Language/scripts of material. Gefur til kynna á hvaða tungumáli skráin er, skv. tungumálakóða staðalsins ISO 639-2.',
  `3_4_4_ytri_einkenni` varchar(1000) DEFAULT NULL COMMENT '3.4.4 Physical characteristics and technical requirements. Veitir upplýsingar um mikilvæg atriði/einkenni  skjalasafnsins sem þarf að taka tillit til við notkun þess eða hvort einhver tæknileg atriði þurfi til/hafi áhrif.',
  `3_4_5_hjálpargögn` varchar(1000) DEFAULT NULL COMMENT '3.4.5 Finding aids. Tilgreinir þau hjálpargögn sem koma að notum við leit í skjalasafninu/notkun þess.',
  `3_5_1_tilvist_frumrita` varchar(1000) DEFAULT NULL COMMENT '3.5.1 Existence and location of originals. Veitir upplýsingar um tilvist, staðsetningu og aðgengi að /eða eyðingu frumrita ef skjalasafnið samanstendur af afritum. Þetta getur átt við um pappírsgögn en einnig um rafræn gögn.',
  `3_5_2_tilvist_afrita` longtext COMMENT '3.5.2 Existence and location of copies. Veitir upplýsingar um tilvist, staðsetningu og aðgengi að /eða eyðingu afrita. Þetta getur átt við um pappírsgögn en einnig um rafræn gögn.',
  `3_5_3_skyld_skjöl` varchar(1000) DEFAULT NULL COMMENT '3.5.3 Related units of description. Veitir upplýsingar um skjalasöfn sem tengjast viðkomandi skjalasafni, v. tilurðar/sögu/starfssemi stofnunar/embættis, eða lífs og starfs einstaklings.',
  `3_5_4_útgáfuupplýsingar` varchar(2000) DEFAULT NULL COMMENT '3.5.4 Publication note. Veitir upplýsingar um útgefið efni sem byggir á skjalsafninu sem heimild eða er rannsókn og greining á skjalasafninu. Tilgreina t.d. tilvísanir í safnið í útgefnum fræðirannsóknum eða öðru efni.',
  `3_6_1_athugasemdir` varchar(2000) DEFAULT NULL COMMENT '3.6.1 Note. Hér koma athugasemdir um atriði (ef við á) varðandi skjalasafnið sem ekki tilheyra öðrum reitum í skránni.',
  `3_7_1_athugasemdir_skjalavarðar` varchar(2000) DEFAULT NULL COMMENT '3.7.1 Archivists Note. Útskýrir hvernig staðið var að gerð lýsingarinnar og hver vann hana.',
  `3_7_2_reglur_venjur` varchar(1000) DEFAULT NULL COMMENT '3.7.2 Rules or Conventions. Veitir upplýsingar um heiti á reglum eða staðli sem unnið er samkvæmt við gerð lýsingarinnar.',
  `3_7_3_dagsetningar` varchar(1000) DEFAULT NULL COMMENT '3.7.3 Date(s) of descriptions. Gefur til kynna hvenær lýsingin var búin til eða uppfærð.',
  `hver_skráði` varchar(200) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dags_skráð` varchar (100) NOT NULL,
  `hver_breytti` varchar(200) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `dags_breytt` varchar (100),
  PRIMARY KEY (`id`),
  UNIQUE KEY `u_auðkenni` (`3_1_1_auðkenni`) USING BTREE,
  KEY `FK_skráningar_vörslustofnanir` (`vörslustofnun`),
  KEY `FK_skráningar_skjalamyndarar` (`skjalamyndari`),
  KEY `ix_upplysingastig` (`3_1_4_upplýsingastig`),
  FULLTEXT KEY `fulltext_allt` (`3_1_2_titill`,`3_1_5_magn_lýsing`,`3_2_1_heiti_skjalamyndara`,`3_2_3_saga_skjalanna`,`3_3_1_yfirlit_innihald`,`3_3_2_tímaáætlanir`,`3_3_3_fyrirsjáanlegar_viðbætur`,`3_3_4_innri_skipan`,`3_4_2_skilyrði_endurprentun`,`3_4_4_ytri_einkenni`,`3_5_1_tilvist_frumrita`,`3_5_2_tilvist_afrita`,`3_6_1_athugasemdir`,`3_7_1_athugasemdir_skjalavarðar`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_midlun`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_midlun` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `vorsluutgafa` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `titill_vorsluutgafu` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `heiti_gagangrunns` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tegund_grunns` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `tafla_grunns` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `dalkur_documentid` varchar(45) DEFAULT NULL,
  `documentid` varchar(45) DEFAULT NULL,
  `dalkur_doctitill` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `doctitill` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `dalkur_docCreated` varchar(45) DEFAULT NULL,
  `docCreated` varchar(45) DEFAULT NULL,
  `dalkur_docLastWriten` varchar(45) DEFAULT NULL,
  `docLastWriten` varchar(45) DEFAULT NULL,
  `dalkur_malID` varchar(45) DEFAULT NULL,
  `malID` varchar(45) DEFAULT NULL,
  `dalkur_malTitill` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `maltitill` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `docInnihald` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `vorslustofnun_audkenni` varchar(45) NOT NULL,
  `vorslustofnun_heiti` varchar(45) NOT NULL,
  `skjalamyndari_audkenni` varchar(45) NOT NULL,
  `skjalamyndari_heiti` varchar(45) NOT NULL,
  `skjalaskra_timabil` varchar(45) NOT NULL,
  `skjalaskra_adgengi` varchar(45) NOT NULL,
  `skjalaskra_afharnr` varchar(45) NOT NULL,
  `skjalaskra_innihald` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `hver_skradi` varchar(45) NOT NULL,
  `dags_skrad` varchar (100) NOT NULL,
  PRIMARY KEY (`id`),
  FULLTEXT KEY `full_text_index` (`vorsluutgafa`,`titill_vorsluutgafu`,`doctitill`,`docLastWriten`,`docInnihald`,`vorslustofnun_heiti`,`skjalamyndari_heiti`,`skjalaskra_timabil`,`skjalaskra_afharnr`,`skjalaskra_innihald`,`maltitill`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_fyrirspurnir`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_fyrirspurnir` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nafn` varchar(100) NOT NULL,
  `fyrirspurn` varchar(500) NOT NULL,
  `lysing` varchar(5000) NOT NULL,
  `gagnagrunnur` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nr` int unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_md5`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_md5` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `AIP` varchar(20) NOT NULL,
  `slod` varchar(300) NOT NULL,
  `file` varchar(200) NOT NULL,
  `MD5` varchar(32) NOT NULL,
  `_date` varchar (100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_notendur`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_notendur` (
  `kennitala` char(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL COMMENT 'Kennitala notanda',
  `notendanafn` varchar(50) DEFAULT NULL COMMENT 'Nafnið sem notandinn notar til að skrá sig í kerfið',
  `lykilorð` varchar(50) DEFAULT NULL COMMENT 'Leyniorðið sem notandinn notar til að skrá sig í kerfið',
  `vörslustofnun` varchar(4) DEFAULT '0' COMMENT 'Vörslustofnunin sem notandinn tilheirir. 0 Þýðir allar stofnanir',
  `nafn` varchar(200) DEFAULT NULL COMMENT 'Fullt nafn notanda',
  `virkur` tinyint(1) DEFAULT '1' COMMENT 'Segir til um hvort notandi geti skráð sig í kerfið',
  `athugasemdir` varchar(1000) DEFAULT NULL COMMENT 'Almennar athugasemdir um notanda',
  `síðasta_innskráning` varchar (100) DEFAULT NULL,
  `hver_skradi` varchar(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `dags_skráð` varchar (100) NOT NULL,
  `hver_breytti` varchar(100) CHARACTER SET latin1 COLLATE latin1_swedish_ci DEFAULT NULL,
  `dags_breytt` varchar (100),
  `hlutverk` enum('Umsjónarmaður','Skjalavörður') NOT NULL,
  `email` varchar(100) NOT NULL COMMENT 'Tölvupostur notanda',
  `heimilisfang` varchar(100) NOT NULL COMMENT 'Heimilsfang notanda',
  `simi` varchar(20) NOT NULL COMMENT 'Simi eða gsm notanda',
  PRIMARY KEY (`kennitala`),
  UNIQUE KEY `notNafn_uniq` (`notendanafn`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_lanthegar`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_lanthegar` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `nafn` varchar(200) NOT NULL,
  `kennitala` varchar(10) NOT NULL,
  `nafn_fyrirtaekis` varchar(200) DEFAULT NULL,
  `kennitala_fyrirtaekis` varchar(10) DEFAULT NULL,
  `simi` varchar(45) NOT NULL,
  `netfang` varchar(45) NOT NULL,
  `dags_skrad` varchar(45) NOT NULL,
  `skrad_af` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_karfa_dip`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_karfa_dip` (
  `karfa` int unsigned NOT NULL AUTO_INCREMENT,
  `heiti` varchar(100) NOT NULL,
  `lanthegi` int unsigned NOT NULL,
  `hver_skradi` varchar(45) NOT NULL,
  `dags_skrad` varchar (100) NOT NULL,
  PRIMARY KEY (`karfa`) USING BTREE,
  KEY `FK_dt_karfa_DIP_1` (`lanthegi`),
  CONSTRAINT `FK_dt_karfa_DIP_1` FOREIGN KEY (`lanthegi`) REFERENCES `dt_lanthegar` (`id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_item_korfu_dip`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_item_korfu_dip` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `karfa` int unsigned NOT NULL,
  `skjalID` int unsigned NOT NULL,
  `titill` varchar(200) NOT NULL,
  `vorsluutgafa` varchar(50) NOT NULL,
  `md5` varchar(100) NOT NULL,
  `slod` varchar(250) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_dt_item_korfu_dip_1` (`karfa`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_item_korfu_mal_dip`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_item_korfu_mal_dip` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `karfa` int unsigned NOT NULL,
  `md5` varchar(100) NOT NULL,
  `vorsluutgafa` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Skrar` int unsigned NOT NULL,
  `slod` varchar(300) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_dt_item_korfu_mal_dip_1` (`karfa`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`dt_karfa_item_gagna_dip`;
CREATE TABLE  `db_oais_admin_afrit`.`dt_karfa_item_gagna_dip` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `karfa` int unsigned NOT NULL,
  `heiti` varchar(200) NOT NULL,
  `vorsluutgafa` varchar(45) NOT NULL,
  `leitarskilyrdi` varchar(500) NOT NULL,
  `sql` varchar(500) NOT NULL,
  `slod` varchar(300) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_dt_karfa_item_gagna_dip_1` (`karfa`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `db_oais_admin_afrit`.`ds_gagnagrunnar`;
CREATE TABLE  `db_oais_admin_afrit`.`ds_gagnagrunnar` (
  `id` int unsigned NOT NULL AUTO_INCREMENT,
  `vorsluutgafa` varchar(45) NOT NULL,
  `heiti_gagnagrunns` varchar(100) NOT NULL,
  `orginal_heiti` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;