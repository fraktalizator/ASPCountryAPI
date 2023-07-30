import pandas as pd
import psycopg2 as sql

SQLUser = "postgres"
SQLPassword = "root"


def getCurrentPopulationData():
    CountryAndPopulationURL = 'https://www.cia.gov/the-world-factbook/field/population/country-comparison/'
    CountryAndRegionURL = 'https://meta.wikimedia.org/wiki/List_of_countries_by_regional_classification'

    Country_Region = pd.read_html(CountryAndRegionURL)
    Country_Region_DF = pd.concat(Country_Region)
    Country_Region_DF.drop(Country_Region_DF.columns[2], inplace=True, axis=1)

    Country_population = pd.read_html(CountryAndPopulationURL)
    Country_population_DF = pd.concat(Country_population)
    Country_population_DF.drop(Country_population_DF.columns[0], inplace=True, axis=1)
    Country_population_DF.drop(Country_population_DF.columns[2], inplace=True, axis=1)
    Country_population_DF = Country_population_DF.rename(columns={Country_population_DF.columns[1]: "Population"})

    Data = Country_population_DF.join(
        Country_Region_DF.set_index("Country"), on="Country"
    )
    return Data


def initRegionTable():
    con = sql.connect(host="localhost", dbname="CountryAPI", user=SQLUser, password=SQLPassword, port=5432)
    cur = con.cursor()

    # cur.execute("DROP TABLE IF EXISTS Regions;")

    # cur.execute("""CREATE TABLE if not exists Regions (
    #             Id SERIAL PRIMARY KEY,
    #             Name TEXT
    # )""")

    regionsList = ["Europe", "Middle east", "Arab States", "South/Latin America", "Asia & Pacific", "North America", "Africa", "South/Central America", "NULL"]
    for regionName in regionsList:
        cur.execute('INSERT INTO "Regions" ("Name") VALUES (%s)', (regionName,))

    con.commit()
    cur.close()
    con.close()


def initCountriesTable():
    con = sql.connect(host="localhost", dbname="CountryAPI", user=SQLUser, password=SQLPassword, port=5432)
    cur = con.cursor()

    # cur.execute("DROP TABLE IF EXISTS Countries;")

    # cur.execute("""CREATE TABLE if not exists Countries (
    #             Id SERIAL  PRIMARY KEY,
    #             Name TEXT,
    #             Population BIGINT,
    #             Region TEXT
    # )""")

    for row in getCurrentPopulationData().iterrows():
        country = row[1].Country
        population = row[1].Population
        if(str(row[1].Region) == 'nan'): row[1].Region = 'NULL'
        #print(row[1].Region)
        regionName = str("'"+row[1].Region+"'")
        #print(regionName)
        cur.execute('SELECT "Id" FROM "Regions" WHERE "Regions"."Name" ='+regionName)
        regionId = cur.fetchall()[0][0]
        #print(regionId)
        cur.execute('INSERT INTO "Countries" ("Name", "Population", "RegionId") VALUES (%s, %s, %s)', (country, population, regionId))

    con.commit()
    cur.close()
    con.close()




initRegionTable()
initCountriesTable()
print("Database is up do date :D")

# for row in getCurrentPopulationData().iterrows():
#     id = row[0]
#     country = row[1].Country
#     population = row[1].Population
#     region = row[1].Region
#     print(region)

#print(getCurrentPopulationData())

#print(Data)
#print(Data.to_sql("Data",conn= engine))



