# WikiScrapper.py
from bs4 import BeautifulSoup
import requests
import re

url = 'https://virtualyoutuber.fandom.com/wiki/Gawr_Gura'

with open ('streamer_data', 'w', encoding='utf-8') as file:
    page = requests.get(url)
    soup = BeautifulSoup(page.content, 'html.parser')
    name = soup.find('h2', class_='pi-item pi-item-spacing pi-title pi-secondary-background').text
    #image = soup.find()
    channel = soup.find('a', href=re.compile('https://www\.youtube\.com/'))['href']
    social_media =  soup.find('a', href=re.compile('https://twitter\.com/gawr'))['href']

    file.write(name + '\n' + channel + '\n' + social_media)


# May be more time efficient to use a predefined list rather than scrapping the wiki as there 
# is going to be variation in how the social media handle is written, i.e
# tokino sora has a handle tokino_sora where as IRyS has irys and gura has gawrgura