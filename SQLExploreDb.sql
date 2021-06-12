create database BooksDb
go 

use BooksDb

--Books-BookID,Title,AuthorID,
--Author-AuthorID,AuthorName
create table tbl_author
(AuthorID int identity(1,1) Primary key, AuthorName varchar(20) )

select * from tbl_author

alter table tbl_author
drop constraint [PK_tbl_auth_70DAFC14840817AD]

drop table tbl_author

create table tbl_author
(AuthorID int identity(1,1) , AuthorName varchar(20),
constraint PK_auth Primary key (AuthorID));

create table tbl_Books
(
   BookID int identity (1000,1),
   Title varchar(50),
   AuthorID int,
   Price money,
   constraint PK_book primary key (BookID),
   constraint FK_auth foreign key (AuthorID) references tbl_author(AuthorID))

   select * from tbl_Books

  --Insert book
   create proc sp_InsBook
@Title varchar(50),
@AuthorID int,
@Price money
as
begin
insert into tbl_Books (Title,AuthorID,Price)
values(@Title,@AuthorID,@Price)
end
--Insert author
create proc sp_InAuthor
@AuthorName varchar(50)
as 
begin
insert into tbl_author(AuthorName)
values(@AuthorName)
end

sp_InsBook 'GoodDay', 7, 400
--Update book
create proc sp_UpdateBook
@Title varchar(50),
@BookId int,
@AuthorID int,
@Price money
as
begin
update tbl_Books
set Title=@Title,AuthorID=@AuthorID,Price=@Price
where BookId=@BookId
end

exec sp_UpdateBook @Title='Two States' , @AuthorID=1, @Price=500 , @BookId=1003
select *from tbl_Books
select * from tbl_author

--update author
create proc sp_UpdateAuthor
@AuthorName varchar(50),
@AuthorID int
as 
begin
update tbl_author
set AuthorName=@AuthorName
where AuthorID=@AuthorID
END

--DELETE BOOK
create proc sp_DeleteBook
@BookId int
as
begin
delete from tbl_Books
where BookId=@BookId
end

sp_DeleteBook @BookId=1014
--Delete Author
create proc sp_DeleteAuthor
@AuthorID INT
as
begin
delete from tbl_author
where AuthorID=@AuthorID
END