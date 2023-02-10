from bs4 import BeautifulSoup
import requests
import re
from datetime import datetime, timedelta
import pytz

urlList = ['https://schedule.hololive.tv/lives/english']
currentDateInTokyo = datetime.now().date()
previousDateInTokyo = (currentDateInTokyo - timedelta(days=1))
nextDateInTokyo = (currentDateInTokyo + timedelta(days=1))

with open('data', 'w', encoding='utf-8') as file:
    for url in urlList:
        # make url req. and scrape
        page = requests.get(url)
        soup = BeautifulSoup(page.content, 'html.parser')
        for card in soup.find_all('div', 'col-6 col-sm-4 col-md-3') :
            file.write(card.find('div', class_='col-4 col-sm-4 col-md-4 text-left datetime').text.replace(' ','').replace('\n', '') + 
                       card.find('div', class_='col text-right name').text.replace(' ','')  + 
                       card.find('a', href=re.compile('https://www\.youtube\.com/'))['href'] )
            file.write('\n')

                    

''' PREVIOUS WORK FOR TRYING TO GET DATE EXTRACTED AND PLACED IN APPROPRIATE AREA
        containers = soup.find_all('div', class_='container')
        for container in containers:
            if ( (container.find('div',style='padding-left:5px;padding-right: 5px;' )) is None ):
                pass
            else:
                if (container.find('br') is not None):
                    pass
                for card in container.find_all('div', 'col-6 col-sm-4 col-md-3'):
                    file.write(container.find('div', class_='holodule navbar-text').text.replace(' ','').replace('\n','')[0:6] + '\n')
                    file.write(card.find('div', class_='col-4 col-sm-4 col-md-4 text-left datetime').text.replace(' ','').replace('\n', '') + 
                               card.find('div', class_='col text-right name').text.replace(' ','')  + 
                               card.find('a', href=re.compile('https://www\.youtube\.com/'))['href'] )
                    file.write('\n')
'''