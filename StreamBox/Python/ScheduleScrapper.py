# ScheduleScrapper.py
from bs4 import BeautifulSoup
import requests
import re
from datetime import datetime, timedelta
import pytz

urlList = ['https://schedule.hololive.tv/lives/hololive',
           'https://schedule.hololive.tv/lives/english',
           'https://schedule.hololive.tv/lives/indonesia']

currentDateInTokyo = datetime.now(pytz.timezone("Asia/Tokyo")).date()
previousDateInTokyo = (currentDateInTokyo - timedelta(1))

with open('data.txt', 'w', encoding='utf-8') as file:
    for url in urlList:
        # make url req. and scrape
        page = requests.get(url)
        soup = BeautifulSoup(page.content, 'html.parser')
        # timeCheck is list to check if a new day has "rolled over"
        timeCheck = [0]
        # incrementedTime will determine how many days will be added to the base day
        incrementedTime = 0
        for card in soup.find_all('div', 'col-6 col-sm-4 col-md-3') :
            timeCheck.append(int(card.find('div', class_='col-4 col-sm-4 col-md-4 text-left datetime').text.replace(' ','').replace('\n', '').replace(':','')))

            if (timeCheck[len(timeCheck) - 1] >= timeCheck[len(timeCheck) - 2]):
                file.write((previousDateInTokyo + timedelta (incrementedTime)).strftime("%d/%m/%Y\n"))
            # if time rolls over i.e. next time is smaller than previous time, then increment
            else:
                incrementedTime = incrementedTime + 1
                file.write( (previousDateInTokyo + timedelta (incrementedTime)).strftime("%d/%m/%Y\n") )
                
            # checking for boundary issue
            if (card.find('a', href=re.compile('https://www\.youtube\.com/')) is not None):
                # write to data file
                file.write(card.find('div', class_='col-4 col-sm-4 col-md-4 text-left datetime').text.replace(' ','').replace('\n', ''))
                file.write(card.find('div', class_='col text-right name').text.replace(' ','') )
                file.write(card.find('a', href=re.compile('https://www\.youtube\.com/'))['href'] )
                file.write('\n')