# UmbrellaAutomation
Simple tool to scrape and prase threat feed's for DNS entries to automatically add to a destinaiton list of your choice.


# What Works
*	Scraping and parsing DNS lists with items on individual lines
* Compare threat feed items and Umbrella list items and adding items NOT in the Umbrella list
* Sending new destinations to Umbrella to add to the block destination list
* Saves local log of console output and function status – saves log name based on current day
* Emails upon error so it is not ignored and the list can be updated if needed while the tool is fixed


# What doesn't work
* The Json parse from Destination list object for some reason only parses 100 items - will debug and fix at some point


## Future Ideas or Fork Idea
You could easily migrate this from .NET Framework (since we run this on windows server) to .NET core and run it on whater OS you want.
A regex function for list parsing from threat feeds for lists's that are not just one line lists.



## Libraries Used
Newtonsoft Json - https://www.nuget.org/packages/Newtonsoft.Json/
