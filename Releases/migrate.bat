if exist "C:\Work\billing_app\packages\FluentMigrator.1.6.2\tools\Migrate.exe" (
    C:\Work\billing_app\packages\FluentMigrator.1.6.2\tools\Migrate.exe -a %~dp0\DbMigrations.dll -db SqlServer2008 -conn "Data Source=.\SQLEXPRESS;Initial Catalog=Company;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=password123;Connect Timeout=30"
) else (
    D:\Work\billing_app\packages\FluentMigrator.1.6.2\tools\Migrate.exe -a %~dp0\DbMigrations.dll -db SqlServer2008 -conn "Data Source=.\SQLEXPRESS;Initial Catalog=Company;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=password123;Connect Timeout=30"
)