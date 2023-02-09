from bs4 import BeautifulSoup
import requests
import re
from deep_translator import GoogleTranslator
import sys

urlList = ['https://schedule.hololive.tv/lives/hololive',
           'https://schedule.hololive.tv/lives/english',
           'https://schedule.hololive.tv/lives/indonesia']

with open('data', 'w',encoding="utf-8") as file:
    for x in urlList:
    # employs BeautifulSoup to scrape data
        page = requests.get(x)
        soup = BeautifulSoup(page.content, "html.parser")
        date = soup.find_all('div', class_='holodule navbar-text')
        stream_cards = soup.find_all('a',href=re.compile('https://www\.youtube\.com/'))
        for stream in stream_cards:
            file.write(stream.find('div', class_='col-4 col-sm-4 col-md-4 text-left datetime').text.replace(' ','').replace('\n', '') + 
            stream.find('div', class_='col text-right name').text.replace(' ','')  + 
            stream['href'])
            file.write('\n')

#TODO: For each x, keep a counter for when the time goes over 24 hr then increment to next day and post before each stream,
#      the first date of streams will always be what the is at top of page that is extracted