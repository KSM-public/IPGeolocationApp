CREATE DATABASE IPGeolocationData
GO
USE IPGeolocationData

CREATE TABLE Continents(
    continent_code VARCHAR(2) NOT NULL PRIMARY KEY,
    continent_name VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Countries(
    country_code VARCHAR(2) NOT NULL PRIMARY KEY,
    country_name VARCHAR(52) NOT NULL
)
GO

CREATE TABLE Addresses(
    address_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    address_ip VARCHAR(39),
    address_url VARCHAR(50)
)
GO

CREATE TABLE GeolocationData(
    geolocationdata_id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    geolocationdata_address int NOT NULL,
    geolocationdata_continent_code VARCHAR(2) NOT NULL,
    geolocationdata_country_code VARCHAR(2) NOT NULL,
    CONSTRAINT FK_GeolocationData_Addresses FOREIGN KEY (geolocationdata_address)
        REFERENCES Addresses(address_id),
    CONSTRAINT FK_GeolocationData_Continents FOREIGN KEY (geolocationdata_continent_code)
        REFERENCES Continents(continent_code),
    CONSTRAINT FK_GeolocationData_Countries FOREIGN KEY (geolocationdata_country_code)
        REFERENCES Countries(country_code),
    geolocationdata_region VARCHAR(50),
    geolocationdata_city VARCHAR(50),
    geolocationdata_zip VARCHAR(15)
)
GO

INSERT INTO Continents (continent_code, continent_name) VALUES
('AF', 'Africa'),
('AN', 'Antarctica'),
('AS', 'Asia'),
('EU', 'Europe'),
('NA', 'North America'),
('OC', 'Oceania'),
('SA', 'South America')

INSERT INTO Countries(country_name,country_code) VALUES ('Afghanistan','AF');
INSERT INTO Countries(country_name,country_code) VALUES ('Åland Islands','AX');
INSERT INTO Countries(country_name,country_code) VALUES ('Albania','AL');
INSERT INTO Countries(country_name,country_code) VALUES ('Algeria','DZ');
INSERT INTO Countries(country_name,country_code) VALUES ('American Samoa','AS');
INSERT INTO Countries(country_name,country_code) VALUES ('Andorra','AD');
INSERT INTO Countries(country_name,country_code) VALUES ('Angola','AO');
INSERT INTO Countries(country_name,country_code) VALUES ('Anguilla','AI');
INSERT INTO Countries(country_name,country_code) VALUES ('Antarctica','AQ');
INSERT INTO Countries(country_name,country_code) VALUES ('Antigua and Barbuda','AG');
INSERT INTO Countries(country_name,country_code) VALUES ('Argentina','AR');
INSERT INTO Countries(country_name,country_code) VALUES ('Armenia','AM');
INSERT INTO Countries(country_name,country_code) VALUES ('Aruba','AW');
INSERT INTO Countries(country_name,country_code) VALUES ('Australia','AU');
INSERT INTO Countries(country_name,country_code) VALUES ('Austria','AT');
INSERT INTO Countries(country_name,country_code) VALUES ('Azerbaijan','AZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Bahamas','BS');
INSERT INTO Countries(country_name,country_code) VALUES ('Bahrain','BH');
INSERT INTO Countries(country_name,country_code) VALUES ('Bangladesh','BD');
INSERT INTO Countries(country_name,country_code) VALUES ('Barbados','BB');
INSERT INTO Countries(country_name,country_code) VALUES ('Belarus','BY');
INSERT INTO Countries(country_name,country_code) VALUES ('Belgium','BE');
INSERT INTO Countries(country_name,country_code) VALUES ('Belize','BZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Benin','BJ');
INSERT INTO Countries(country_name,country_code) VALUES ('Bermuda','BM');
INSERT INTO Countries(country_name,country_code) VALUES ('Bhutan','BT');
INSERT INTO Countries(country_name,country_code) VALUES ('Bolivia, Plurinational State of','BO');
INSERT INTO Countries(country_name,country_code) VALUES ('Bonaire, Sint Eustatius and Saba','BQ');
INSERT INTO Countries(country_name,country_code) VALUES ('Bosnia and Herzegovina','BA');
INSERT INTO Countries(country_name,country_code) VALUES ('Botswana','BW');
INSERT INTO Countries(country_name,country_code) VALUES ('Bouvet Island','BV');
INSERT INTO Countries(country_name,country_code) VALUES ('Brazil','BR');
INSERT INTO Countries(country_name,country_code) VALUES ('British Indian Ocean Territory','IO');
INSERT INTO Countries(country_name,country_code) VALUES ('Brunei Darussalam','BN');
INSERT INTO Countries(country_name,country_code) VALUES ('Bulgaria','BG');
INSERT INTO Countries(country_name,country_code) VALUES ('Burkina Faso','BF');
INSERT INTO Countries(country_name,country_code) VALUES ('Burundi','BI');
INSERT INTO Countries(country_name,country_code) VALUES ('Cabo Verde','CV');
INSERT INTO Countries(country_name,country_code) VALUES ('Cambodia','KH');
INSERT INTO Countries(country_name,country_code) VALUES ('Cameroon','CM');
INSERT INTO Countries(country_name,country_code) VALUES ('Canada','CA');
INSERT INTO Countries(country_name,country_code) VALUES ('Cayman Islands','KY');
INSERT INTO Countries(country_name,country_code) VALUES ('Central African Republic','CF');
INSERT INTO Countries(country_name,country_code) VALUES ('Chad','TD');
INSERT INTO Countries(country_name,country_code) VALUES ('Chile','CL');
INSERT INTO Countries(country_name,country_code) VALUES ('China','CN');
INSERT INTO Countries(country_name,country_code) VALUES ('Christmas Island','CX');
INSERT INTO Countries(country_name,country_code) VALUES ('Cocos (Keeling) Islands','CC');
INSERT INTO Countries(country_name,country_code) VALUES ('Colombia','CO');
INSERT INTO Countries(country_name,country_code) VALUES ('Comoros','KM');
INSERT INTO Countries(country_name,country_code) VALUES ('Congo','CG');
INSERT INTO Countries(country_name,country_code) VALUES ('Congo, Democratic Republic of the','CD');
INSERT INTO Countries(country_name,country_code) VALUES ('Cook Islands','CK');
INSERT INTO Countries(country_name,country_code) VALUES ('Costa Rica','CR');
INSERT INTO Countries(country_name,country_code) VALUES ('Côte d''Ivoire','CI');
INSERT INTO Countries(country_name,country_code) VALUES ('Croatia','HR');
INSERT INTO Countries(country_name,country_code) VALUES ('Cuba','CU');
INSERT INTO Countries(country_name,country_code) VALUES ('Curaçao','CW');
INSERT INTO Countries(country_name,country_code) VALUES ('Cyprus','CY');
INSERT INTO Countries(country_name,country_code) VALUES ('Czechia','CZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Denmark','DK');
INSERT INTO Countries(country_name,country_code) VALUES ('Djibouti','DJ');
INSERT INTO Countries(country_name,country_code) VALUES ('Dominica','DM');
INSERT INTO Countries(country_name,country_code) VALUES ('Dominican Republic','DO');
INSERT INTO Countries(country_name,country_code) VALUES ('Ecuador','EC');
INSERT INTO Countries(country_name,country_code) VALUES ('Egypt','EG');
INSERT INTO Countries(country_name,country_code) VALUES ('El Salvador','SV');
INSERT INTO Countries(country_name,country_code) VALUES ('Equatorial Guinea','GQ');
INSERT INTO Countries(country_name,country_code) VALUES ('Eritrea','ER');
INSERT INTO Countries(country_name,country_code) VALUES ('Estonia','EE');
INSERT INTO Countries(country_name,country_code) VALUES ('Eswatini','SZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Ethiopia','ET');
INSERT INTO Countries(country_name,country_code) VALUES ('Falkland Islands (Malvinas)','FK');
INSERT INTO Countries(country_name,country_code) VALUES ('Faroe Islands','FO');
INSERT INTO Countries(country_name,country_code) VALUES ('Fiji','FJ');
INSERT INTO Countries(country_name,country_code) VALUES ('Finland','FI');
INSERT INTO Countries(country_name,country_code) VALUES ('France','FR');
INSERT INTO Countries(country_name,country_code) VALUES ('French Guiana','GF');
INSERT INTO Countries(country_name,country_code) VALUES ('French Polynesia','PF');
INSERT INTO Countries(country_name,country_code) VALUES ('French Southern Territories','TF');
INSERT INTO Countries(country_name,country_code) VALUES ('Gabon','GA');
INSERT INTO Countries(country_name,country_code) VALUES ('Gambia','GM');
INSERT INTO Countries(country_name,country_code) VALUES ('Georgia','GE');
INSERT INTO Countries(country_name,country_code) VALUES ('Germany','DE');
INSERT INTO Countries(country_name,country_code) VALUES ('Ghana','GH');
INSERT INTO Countries(country_name,country_code) VALUES ('Gibraltar','GI');
INSERT INTO Countries(country_name,country_code) VALUES ('Greece','GR');
INSERT INTO Countries(country_name,country_code) VALUES ('Greenland','GL');
INSERT INTO Countries(country_name,country_code) VALUES ('Grenada','GD');
INSERT INTO Countries(country_name,country_code) VALUES ('Guadeloupe','GP');
INSERT INTO Countries(country_name,country_code) VALUES ('Guam','GU');
INSERT INTO Countries(country_name,country_code) VALUES ('Guatemala','GT');
INSERT INTO Countries(country_name,country_code) VALUES ('Guernsey','GG');
INSERT INTO Countries(country_name,country_code) VALUES ('Guinea','GN');
INSERT INTO Countries(country_name,country_code) VALUES ('Guinea-Bissau','GW');
INSERT INTO Countries(country_name,country_code) VALUES ('Guyana','GY');
INSERT INTO Countries(country_name,country_code) VALUES ('Haiti','HT');
INSERT INTO Countries(country_name,country_code) VALUES ('Heard Island and McDonald Islands','HM');
INSERT INTO Countries(country_name,country_code) VALUES ('Holy See','VA');
INSERT INTO Countries(country_name,country_code) VALUES ('Honduras','HN');
INSERT INTO Countries(country_name,country_code) VALUES ('Hong Kong','HK');
INSERT INTO Countries(country_name,country_code) VALUES ('Hungary','HU');
INSERT INTO Countries(country_name,country_code) VALUES ('Iceland','IS');
INSERT INTO Countries(country_name,country_code) VALUES ('India','IN');
INSERT INTO Countries(country_name,country_code) VALUES ('Indonesia','ID');
INSERT INTO Countries(country_name,country_code) VALUES ('Iran, Islamic Republic of','IR');
INSERT INTO Countries(country_name,country_code) VALUES ('Iraq','IQ');
INSERT INTO Countries(country_name,country_code) VALUES ('Ireland','IE');
INSERT INTO Countries(country_name,country_code) VALUES ('Isle of Man','IM');
INSERT INTO Countries(country_name,country_code) VALUES ('Israel','IL');
INSERT INTO Countries(country_name,country_code) VALUES ('Italy','IT');
INSERT INTO Countries(country_name,country_code) VALUES ('Jamaica','JM');
INSERT INTO Countries(country_name,country_code) VALUES ('Japan','JP');
INSERT INTO Countries(country_name,country_code) VALUES ('Jersey','JE');
INSERT INTO Countries(country_name,country_code) VALUES ('Jordan','JO');
INSERT INTO Countries(country_name,country_code) VALUES ('Kazakhstan','KZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Kenya','KE');
INSERT INTO Countries(country_name,country_code) VALUES ('Kiribati','KI');
INSERT INTO Countries(country_name,country_code) VALUES ('Korea, Democratic People''s Republic of','KP');
INSERT INTO Countries(country_name,country_code) VALUES ('Korea, Republic of','KR');
INSERT INTO Countries(country_name,country_code) VALUES ('Kuwait','KW');
INSERT INTO Countries(country_name,country_code) VALUES ('Kyrgyzstan','KG');
INSERT INTO Countries(country_name,country_code) VALUES ('Lao People''s Democratic Republic','LA');
INSERT INTO Countries(country_name,country_code) VALUES ('Latvia','LV');
INSERT INTO Countries(country_name,country_code) VALUES ('Lebanon','LB');
INSERT INTO Countries(country_name,country_code) VALUES ('Lesotho','LS');
INSERT INTO Countries(country_name,country_code) VALUES ('Liberia','LR');
INSERT INTO Countries(country_name,country_code) VALUES ('Libya','LY');
INSERT INTO Countries(country_name,country_code) VALUES ('Liechtenstein','LI');
INSERT INTO Countries(country_name,country_code) VALUES ('Lithuania','LT');
INSERT INTO Countries(country_name,country_code) VALUES ('Luxembourg','LU');
INSERT INTO Countries(country_name,country_code) VALUES ('Macao','MO');
INSERT INTO Countries(country_name,country_code) VALUES ('Madagascar','MG');
INSERT INTO Countries(country_name,country_code) VALUES ('Malawi','MW');
INSERT INTO Countries(country_name,country_code) VALUES ('Malaysia','MY');
INSERT INTO Countries(country_name,country_code) VALUES ('Maldives','MV');
INSERT INTO Countries(country_name,country_code) VALUES ('Mali','ML');
INSERT INTO Countries(country_name,country_code) VALUES ('Malta','MT');
INSERT INTO Countries(country_name,country_code) VALUES ('Marshall Islands','MH');
INSERT INTO Countries(country_name,country_code) VALUES ('Martinique','MQ');
INSERT INTO Countries(country_name,country_code) VALUES ('Mauritania','MR');
INSERT INTO Countries(country_name,country_code) VALUES ('Mauritius','MU');
INSERT INTO Countries(country_name,country_code) VALUES ('Mayotte','YT');
INSERT INTO Countries(country_name,country_code) VALUES ('Mexico','MX');
INSERT INTO Countries(country_name,country_code) VALUES ('Micronesia, Federated States of','FM');
INSERT INTO Countries(country_name,country_code) VALUES ('Moldova, Republic of','MD');
INSERT INTO Countries(country_name,country_code) VALUES ('Monaco','MC');
INSERT INTO Countries(country_name,country_code) VALUES ('Mongolia','MN');
INSERT INTO Countries(country_name,country_code) VALUES ('Montenegro','ME');
INSERT INTO Countries(country_name,country_code) VALUES ('Montserrat','MS');
INSERT INTO Countries(country_name,country_code) VALUES ('Morocco','MA');
INSERT INTO Countries(country_name,country_code) VALUES ('Mozambique','MZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Myanmar','MM');
INSERT INTO Countries(country_name,country_code) VALUES ('Namibia','NA');
INSERT INTO Countries(country_name,country_code) VALUES ('Nauru','NR');
INSERT INTO Countries(country_name,country_code) VALUES ('Nepal','NP');
INSERT INTO Countries(country_name,country_code) VALUES ('Netherlands, Kingdom of the','NL');
INSERT INTO Countries(country_name,country_code) VALUES ('New Caledonia','NC');
INSERT INTO Countries(country_name,country_code) VALUES ('New Zealand','NZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Nicaragua','NI');
INSERT INTO Countries(country_name,country_code) VALUES ('Niger','NE');
INSERT INTO Countries(country_name,country_code) VALUES ('Nigeria','NG');
INSERT INTO Countries(country_name,country_code) VALUES ('Niue','NU');
INSERT INTO Countries(country_name,country_code) VALUES ('Norfolk Island','NF');
INSERT INTO Countries(country_name,country_code) VALUES ('North Macedonia','MK');
INSERT INTO Countries(country_name,country_code) VALUES ('Northern Mariana Islands','MP');
INSERT INTO Countries(country_name,country_code) VALUES ('Norway','NO');
INSERT INTO Countries(country_name,country_code) VALUES ('Oman','OM');
INSERT INTO Countries(country_name,country_code) VALUES ('Pakistan','PK');
INSERT INTO Countries(country_name,country_code) VALUES ('Palau','PW');
INSERT INTO Countries(country_name,country_code) VALUES ('Palestine, State of','PS');
INSERT INTO Countries(country_name,country_code) VALUES ('Panama','PA');
INSERT INTO Countries(country_name,country_code) VALUES ('Papua New Guinea','PG');
INSERT INTO Countries(country_name,country_code) VALUES ('Paraguay','PY');
INSERT INTO Countries(country_name,country_code) VALUES ('Peru','PE');
INSERT INTO Countries(country_name,country_code) VALUES ('Philippines','PH');
INSERT INTO Countries(country_name,country_code) VALUES ('Pitcairn','PN');
INSERT INTO Countries(country_name,country_code) VALUES ('Poland','PL');
INSERT INTO Countries(country_name,country_code) VALUES ('Portugal','PT');
INSERT INTO Countries(country_name,country_code) VALUES ('Puerto Rico','PR');
INSERT INTO Countries(country_name,country_code) VALUES ('Qatar','QA');
INSERT INTO Countries(country_name,country_code) VALUES ('Réunion','RE');
INSERT INTO Countries(country_name,country_code) VALUES ('Romania','RO');
INSERT INTO Countries(country_name,country_code) VALUES ('Russian Federation','RU');
INSERT INTO Countries(country_name,country_code) VALUES ('Rwanda','RW');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Barthélemy','BL');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Helena, Ascension and Tristan da Cunha','SH');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Kitts and Nevis','KN');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Lucia','LC');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Martin (French part)','MF');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Pierre and Miquelon','PM');
INSERT INTO Countries(country_name,country_code) VALUES ('Saint Vincent and the Grenadines','VC');
INSERT INTO Countries(country_name,country_code) VALUES ('Samoa','WS');
INSERT INTO Countries(country_name,country_code) VALUES ('San Marino','SM');
INSERT INTO Countries(country_name,country_code) VALUES ('Sao Tome and Principe','ST');
INSERT INTO Countries(country_name,country_code) VALUES ('Saudi Arabia','SA');
INSERT INTO Countries(country_name,country_code) VALUES ('Senegal','SN');
INSERT INTO Countries(country_name,country_code) VALUES ('Serbia','RS');
INSERT INTO Countries(country_name,country_code) VALUES ('Seychelles','SC');
INSERT INTO Countries(country_name,country_code) VALUES ('Sierra Leone','SL');
INSERT INTO Countries(country_name,country_code) VALUES ('Singapore','SG');
INSERT INTO Countries(country_name,country_code) VALUES ('Sint Maarten (Dutch part)','SX');
INSERT INTO Countries(country_name,country_code) VALUES ('Slovakia','SK');
INSERT INTO Countries(country_name,country_code) VALUES ('Slovenia','SI');
INSERT INTO Countries(country_name,country_code) VALUES ('Solomon Islands','SB');
INSERT INTO Countries(country_name,country_code) VALUES ('Somalia','SO');
INSERT INTO Countries(country_name,country_code) VALUES ('South Africa','ZA');
INSERT INTO Countries(country_name,country_code) VALUES ('South Georgia and the South Sandwich Islands','GS');
INSERT INTO Countries(country_name,country_code) VALUES ('South Sudan','SS');
INSERT INTO Countries(country_name,country_code) VALUES ('Spain','ES');
INSERT INTO Countries(country_name,country_code) VALUES ('Sri Lanka','LK');
INSERT INTO Countries(country_name,country_code) VALUES ('Sudan','SD');
INSERT INTO Countries(country_name,country_code) VALUES ('Suriname','SR');
INSERT INTO Countries(country_name,country_code) VALUES ('Svalbard and Jan Mayen','SJ');
INSERT INTO Countries(country_name,country_code) VALUES ('Sweden','SE');
INSERT INTO Countries(country_name,country_code) VALUES ('Switzerland','CH');
INSERT INTO Countries(country_name,country_code) VALUES ('Syrian Arab Republic','SY');
INSERT INTO Countries(country_name,country_code) VALUES ('Taiwan, Province of China','TW');
INSERT INTO Countries(country_name,country_code) VALUES ('Tajikistan','TJ');
INSERT INTO Countries(country_name,country_code) VALUES ('Tanzania, United Republic of','TZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Thailand','TH');
INSERT INTO Countries(country_name,country_code) VALUES ('Timor-Leste','TL');
INSERT INTO Countries(country_name,country_code) VALUES ('Togo','TG');
INSERT INTO Countries(country_name,country_code) VALUES ('Tokelau','TK');
INSERT INTO Countries(country_name,country_code) VALUES ('Tonga','TO');
INSERT INTO Countries(country_name,country_code) VALUES ('Trinidad and Tobago','TT');
INSERT INTO Countries(country_name,country_code) VALUES ('Tunisia','TN');
INSERT INTO Countries(country_name,country_code) VALUES ('Türkiye','TR');
INSERT INTO Countries(country_name,country_code) VALUES ('Turkmenistan','TM');
INSERT INTO Countries(country_name,country_code) VALUES ('Turks and Caicos Islands','TC');
INSERT INTO Countries(country_name,country_code) VALUES ('Tuvalu','TV');
INSERT INTO Countries(country_name,country_code) VALUES ('Uganda','UG');
INSERT INTO Countries(country_name,country_code) VALUES ('Ukraine','UA');
INSERT INTO Countries(country_name,country_code) VALUES ('United Arab Emirates','AE');
INSERT INTO Countries(country_name,country_code) VALUES ('United Kingdom of Great Britain and Northern Ireland','GB');
INSERT INTO Countries(country_name,country_code) VALUES ('United States of America','US');
INSERT INTO Countries(country_name,country_code) VALUES ('United States Minor Outlying Islands','UM');
INSERT INTO Countries(country_name,country_code) VALUES ('Uruguay','UY');
INSERT INTO Countries(country_name,country_code) VALUES ('Uzbekistan','UZ');
INSERT INTO Countries(country_name,country_code) VALUES ('Vanuatu','VU');
INSERT INTO Countries(country_name,country_code) VALUES ('Venezuela, Bolivarian Republic of','VE');
INSERT INTO Countries(country_name,country_code) VALUES ('Viet Nam','VN');
INSERT INTO Countries(country_name,country_code) VALUES ('Virgin Islands (British)','VG');
INSERT INTO Countries(country_name,country_code) VALUES ('Virgin Islands (U.S.)','VI');
INSERT INTO Countries(country_name,country_code) VALUES ('Wallis and Futuna','WF');
INSERT INTO Countries(country_name,country_code) VALUES ('Western Sahara','EH');
INSERT INTO Countries(country_name,country_code) VALUES ('Yemen','YE');
INSERT INTO Countries(country_name,country_code) VALUES ('Zambia','ZM');
INSERT INTO Countries(country_name,country_code) VALUES ('Zimbabwe','ZW');
