
# Simple ASP Web API

**Project Setup**:
1. create postgresql database named CountryAPI (Case sensitive)
2. change default 'SQLUser'and 'SQLPassword' in seed.py script to whatewer you have set on your postgres
3. run in Package Manager Console:
- Add-Migration Init
- Update-Database
4. run in powershell ( Requires python3 and its modules: pandas, psycopg2 )
- cd .\CountryApiCom\
- python .\seed.py 
