--create database test

create table student (id int,name varchar(50),lname varchar (30))
insert into student values(7,'vihan','patel')
update student SET lname='solanki' where id=2
delete from student where id=2
select * from student

create table subjesh(id int primary key identity , subjectname varchar(50))

insert into subjesh values('PHICS')

select * from subjesh

truncate table subjesh
delete from subjesh

-- return all record from left table and from right table only maching 
select * from subjesh as S
left join student as St
on S.id=St.id

-- return all record from right table and from left table only maching 
select * from subjesh as S
right join student as St
on S.id=St.id

-- return all maching record
select * from subjesh as S
inner join student as St
on S.id=St.id

-- return all record 
select * from subjesh as S
full join student as St
on S.id=St.id

