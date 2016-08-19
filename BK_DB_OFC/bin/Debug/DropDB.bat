@echo off
SET PGPASSWORD=%2
cd C:\Program Files (x86)\PostgreSQL\9.1\bin
dropdb -h localhost -p 5432 -U postgres %1
