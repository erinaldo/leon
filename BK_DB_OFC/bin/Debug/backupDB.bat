@echo off
for /f "tokens=1-3 delims=/ " %%i in ("%date%") do (
set day=%%i
set month=%%j
set year=%%k
)
set datestr=%year%_%month%_%day%
set BACKUP_FILE=C:\backup\%1_%datestr%.backup
SET PGPASSWORD=%2
cd C:\Program Files (x86)\PostgreSQL\9.1\bin
@echo on
pg_dump -i -h localhost -p 5432 -U postgres -F c -b -v -f %BACKUP_FILE% %1
