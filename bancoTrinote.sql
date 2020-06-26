create database TrinoteTeste
go
use TrinoteTeste
go
create table Cargo 
(
	idCargo int primary key identity,
	nomeCargo varchar(30),
)
go
create table Funcionario
(
idFuncionario int identity (1,1) not null primary key,
nomeFuncionario VARCHAR(50) not null,
permissaoFuncionario int references Cargo (idCargo),
loginfuncionario varchar(20) not null,
senhafuncionario varchar(20) not null,
statusfuncionario bit not null
)
go
create table Usuario
(
idUsuario int identity (1,1) not null primary key,
nomeUsuario VARCHAR(50) not null,
emailUsuario VARCHAR(50) not null,
telefoneUsuario VARCHAR(20) not null,
loginUsuario varchar(20) not null,
senhaUsuario varchar(20) not null,
premium bit not null,
precoAssinatura money,
foto varbinary(max)
)
go
create table Anunciante
(
idAnunciante int identity (1,1) not null primary key,
nomeAnunciante VARCHAR(50) not null,
emailAnunciante VARCHAR(50) not null,
telefoneAnunciante VARCHAR(20) not null,
cnpj varchar(14) not null,
loginAnunciante varchar(20) not null,
senhaAnunciante varchar(20) not null
)
go
create table Grupo
(
idGrupo int identity (1,1) not null primary key,
nomeGrupo varchar(20) not null,
fotoGrupo varbinary(max),
descricao varchar(255),
dataHoraCriacao datetime not null
)
go
create table Anotacao
(
idAnotacao int identity (1,1) not null primary key,
Grupo_idGrupo INT foreign key references Grupo (idGrupo),
usuarioCria INT  references Usuario (idUsuario),
usuarioVisualiza INT  references Usuario (idUsuario),
usuarioAltera INT  references Usuario (idUsuario),
usuarioComenta INT  references Usuario (idUsuario),
usuarioExclui INT  references Usuario (idUsuario),
titulo varchar(20) not null,
conteudo varchar(255),
Font Varchar(50),
dataHoraCriacao datetime not null,
dataHoraAlteracao datetime,
dataHoraComentario datetime,
dataHoraExclusao datetime,
Imagem varbinary(max),
statusAnotacao bit not null
)
go
create table Anuncio
(
idAnuncio int identity (1,1) not null primary key,
Anunciante_idAnunciante INT foreign key references Anunciante (idAnunciante),
titulo varchar(50) not null,
imagem varbinary(max),
valor money,
descricao varchar(max) not null,
link varchar(255),
dataTermino datetime,
validacao int not null,
causa varchar (255),
funcionarioValidou int references Funcionario (idFuncionario)
)
go
create table Solicitacao
(
	idSolicitacao int primary key identity,
	idUsuario int foreign key references Usuario (idUsuario),
	dataHoraInicioSol datetime not null,
	dataHoraTerminoSol datetime,
	Motivo varchar(20),
	emEspera bit,
	emAberto bit
)
go
create table Mensagem
(
idMensagem int primary key identity,
idFuncionario int references Funcionario (idFuncionario),
idSolicitacao int foreign key references Solicitacao (idSolicitacao),
isUsuario bit,
txtMensagem varchar(300),
dataHoraMensagem DATETIME,
)
--go

--Tabela de Teste(Seram Nescessarias alterações)
--Pode ser Chamada tambem de Pedido de Amizade
--Aqui é gravado o id do usuario que esta solicitando amizade
create table Individuo(
idIndividuo int primary key identity,
idUsuario int foreign key references Usuario(idUsuario)
)
--no id do usuario vai ser gravdo o id do usuario que aceitou o pedido de amizade ou visce e versa
--no id do individuo vai o id de quem esta pedindo a amizade
create table Amigos(
idAmigo int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
idIndividuo int foreign key references Individuo(idIndividuo),
Solicitacao bit,
Recusadas bit
)
select * from Usuario
select * from Individuo

insert into Individuo(idUsuario) values(1)
insert into Individuo(idUsuario) values(2)
select * from Individuo
---Amigo Fazendo Pedido de Amizade//Amigo que vai ser adicionado
insert into Amigos(idUsuario,idIndividuo) values(2,2)
insert into Amigos(idUsuario,idIndividuo) values(1,3)
--Busca Todos os amigos
Select * from Amigos F
     JOIN Individuo U on F.idIndividuo=U.idIndividuo --// Get all Amigos of all Individuo
     JOIN Usuario I on I.idUsuario =F.idUsuario --// Get there nomeUsuario
   --Where I.Name = 'MyFriend' --// filter a friend
--solicitação Enviada
Select U.nomeUsuario,A.idAmigo from Amigos A 
        JOIN Individuo I on A.idIndividuo = I.idIndividuo
        JOIN Usuario U on A.idUsuario = U.idUsuario
        Where I.idUsuario = 1 and A.Solicitacao = 0
--Amigos
Select U.nomeUsuario as 'quem adicionou',UA.nomeUsuario 'Adicionado',A.idAmigo from Amigos A 
        JOIN Individuo I on A.idIndividuo = I.idIndividuo
        JOIN Usuario U on I.idUsuario = U.idUsuario
		Join Usuario UA on A.idUsuario = UA.idUsuario
        Where A.idUsuario = 2 and A.Solicitacao = 1 or I.idUsuario = 1 and A.Solicitacao = 1
--Solicitação Recebida
Select U.nomeUsuario,U.foto,I.idUsuario from Individuo I 
        JOIN Amigos A on I.idIndividuo = A.idIndividuo 
        JOIN Usuario U on I.idUsuario = U.idUsuario 
        Where A.Solicitacao = 0 and A.idUsuario = 2
---------------------------------------
create table Compartilhamento(
idCompartilhamento int primary key identity,
idUsuario int foreign key references Usuario(idUsuario),
idAmigo int foreign key references Amigos(idAmigo),
idAnotacao int foreign key references Anotacao(idAnotacao),
)



select * from Compartilhamento C
        JOIN Usuario U on U.idUsuario = C.idUsuario
        JOIN Amigos A on A.idAmigo = C.idAmigo
        JOIN Individuo I on I.idIndividuo =  A.idIndividuo
    Where C.idUsuario = 1 and C.idUsuario = I.idUsuario and A.idUsuario = 2

select * from Usuario

select A.usuarioCria,A.titulo,A.conteudo,A.Font,A.Imagem,U.loginUsuario from Compartilhamento C 
                                    JOIN Anotacao A on C.idAnotacao = A.idAnotacao 
                                    JOIN Amigos AMI on C.idAmigo = AMI.idAmigo
									JOIN Individuo I on AMI.idIndividuo = I.idIndividuo
									JOIN Usuario U on I.idUsuario = U.idUsuario 
                              where I.idUsuario = 1 
--go
insert into Cargo values ('Suporte')
insert into Cargo values ('Marketing')
insert into Cargo values ('Gerência')
insert into Cargo values ('Admin')
go
insert into Funcionario(loginFuncionario,senhaFuncionario,permissaoFuncionario,nomeFuncionario,statusfuncionario) values ('1','1',1,'Lucas',1)
insert into Funcionario(loginFuncionario,senhaFuncionario,permissaoFuncionario,nomeFuncionario,statusfuncionario) values ('2','2',2,'Felipe',1)
insert into Funcionario(loginFuncionario,senhaFuncionario,permissaoFuncionario,nomeFuncionario,statusfuncionario) values ('3','3',3,'José',1)
insert into Funcionario(loginFuncionario,senhaFuncionario,permissaoFuncionario,nomeFuncionario,statusfuncionario) values ('4','4',4,'Marina',1)
go
insert into Grupo(nomeGrupo,dataHoraCriacao) values('Anotações Padrão','')

insert into Usuario (nomeUsuario,premium,loginUsuario,senhaUsuario, emailUsuario,telefoneUsuario) values ('Kevin', 0,'a','a','kevin@gmail.com',12345678)
insert into Usuario (nomeUsuario,premium,loginUsuario,senhaUsuario, emailUsuario,telefoneUsuario) values ('Xerto', 1,'b','b','xerto@gmail.com',12345678)
insert into Usuario (nomeUsuario,premium,loginUsuario,senhaUsuario, emailUsuario,telefoneUsuario) values ('Bruno', 2,'c','c','bruno@gmail.com',12345678)
insert into Usuario (nomeUsuario,premium,loginUsuario,senhaUsuario, emailUsuario,telefoneUsuario) values ('Viana', 3,'c','c','viana@gmail.com',12345678)

insert into Solicitacao (idUsuario,dataHoraInicioSol,emEspera) values (1,getdate(),1)
insert into Solicitacao (idUsuario,dataHoraInicioSol,emEspera) values (2,getdate(),1)
insert into Solicitacao (idUsuario,dataHoraInicioSol,emEspera) values (3,getdate(),1)
insert into Solicitacao (idUsuario,dataHoraInicioSol,emEspera) values (4,getdate(),1)

insert into mensagem (idSolicitacao,txtMensagem,dataHoraMensagem,isUsuario) values (1,'Estou entrando em contato para elogiar o TriNote, melhor aplicativo!! Vai Brasil!',getdate(),1)
insert into mensagem (idSolicitacao,txtMensagem,dataHoraMensagem,isUsuario) values (4,'Minha ID é 4',getdate(),1)

insert into anunciante (nomeAnunciante,emailAnunciante,telefoneAnunciante,cnpj,loginAnunciante,senhaAnunciante) values ('Bruno', 'faf@gmail.com',12345678,11111111,1,1)
insert into anunciante (nomeAnunciante,emailAnunciante,telefoneAnunciante,cnpj,loginAnunciante,senhaAnunciante) values ('Tadeu', 'tadeu@gmail.com',12345678,11111111,2,2)

select * from Anunciante
select * from anuncio

insert into anuncio (Anunciante_idAnunciante,valor ,titulo,descricao,validacao,dataTermino) values (1,500,'Melhor produto CabeShow', 'Para os seus cabelos',0,'12-01-2020')
insert into anuncio (Anunciante_idAnunciante,valor,titulo,descricao,validacao,dataTermino) values (2,200,'SorriDente', 'For the tooth',0,'12-01-2020')

update Solicitacao set emEspera = 1 

-------------------------------------------------------------------------------

select * from Anunciante
select * from Anuncio
select * from solicitacao
update Anuncio set validacao = 1 where idAnuncio = 3

insert into Grupo(nomeGrupo,dataHoraCriacao) values('Anotações Padrão','')

select * from Anotacao
select * from Usuario
update Usuario set loginUsuario = 'Desativado' where idUsuario = 1
select titulo,conteudo,Imagem from Anotacao where usuarioCria = 3 and statusAnotacao = 1

Insert into Anotacao(Grupo_idGrupo,usuarioCria,usuarioVisualiza,usuarioAltera,usuarioComenta,usuarioExclui,titulo,conteudo,statusAnotacao) Values(1,1,1,1,1,1,'aa','bb',1)

select * from Grupo

alter table anuncio
add descricao varchar(max) 

-- 09.11.2019

update Solicitacao set emEspera = 1
select * from solicitacao

update solicitacao
set emAberto = 1

update solicitacao
set dataHoraTerminoSol = null

update solicitacao
set dataHoraTerminoSol = '2000-01-01 00:00:00.000', emAberto = 0

select * from solicitacao where emEspera = 0 and dataHoraTerminoSol is not null and emAberto = 1
select * from solicitacao where emEspera = 0 and dataHoraTerminoSol is not null and emAberto = 0

update Solicitacao set dataHoraTerminoSol = '2000-01-01 00:00:00.000' where idUsuario = 1
update Solicitacao set dataHoraTerminoSol = getdate() where idUsuario = 1

select * from Solicitacao where dataHoraTerminoSol > '2000-01-01 00:00:00.000'

select * from anuncio where idAnuncio = 1

select * from Usuario

insert into Grupo(nomeGrupo,dataHoraCriacao) values('Padrão','2000-01-01 00:00:00.000')

update Anotacao set statusAnotacao = 0 where idAnotacao = 1

select Usuario.nomeUsuario, Usuario.idUsuario, Solicitacao.idSolicitacao from Usuario,Solicitacao where Usuario.nomeUsuario = Usuario.nomeUsuario and Usuario.idUsuario = Solicitacao.idUsuario and Solicitacao.emEspera = 1

select * from funcionario

update funcionario
set permissaoFuncionario = 3
where nomeFuncionario = 'José'

select * from anunciante

select (select nomeAnunciante from Anunciante where idAnunciante = Anunciante_idAnunciante) as nomeAnunciante,idAnuncio,valor,validacao,dataTermino,titulo,descricao from anuncio where dataTermino < GETDATE() and validacao is not null
select * from Anuncio

update Anuncio set validacao = 0

select (select nomeAnunciante from Anunciante where idAnunciante = Anunciante_idAnunciante) as nomeAnunciante,idAnuncio,valor,validacao,dataTermino,titulo,descricao from anuncio where validacao is not null


select * from Solicitacao

insert into Mensagem (idSolicitacao,isUsuario,txtMensagem,dataHoraMensagem) values (1,0,'texto',getdate())
select * from mensagem

insert into Solicitacao (idUsuario,emEspera,emAberto) values (3,1,0)


Alter table Anotacao Add Font Varchar(50)
Select * from Anotacao