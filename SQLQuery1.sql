create database EFM_REGIO_V4
use EFM_REGIO_V4

create table Client(CIN Varchar(10) primary key , ADRESSE varchar(50), tel varchar(10), ACTIVE varchar(20))

alter table client
add NOM varchar(20)

select * from ABONNEMENTS
select * from PAYEMENTS


create table ABONNEMENTS (ID_ABONN int primary key, CIN Varchar(10) foreign key references Client(CIN),DATE_ABONN datetime,TYPEE varchar(20),ETAT varchar(20))
create table PAYEMENTS(ID_ABONN int foreign key references ABONNEMENTS (ID_ABONN),PERIODE date,TOTAL float,PENALITE Varchar(30), PAYE varchar(10),primary key(ID_ABONN,PERIODE)  )