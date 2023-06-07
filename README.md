# eBay API Integration
This project is a Windows Forms application that integrates with the eBay API to search for items based on user input and display the results.

## Getting Started
To run the application and use the eBay API integration, follow these steps:

Clone or download the project files to your local machine.
Open the project in Visual Studio or your preferred IDE.
Make sure you have the necessary dependencies installed, including the eBayAPIIntegration library.
Update the configuration settings in the app.config file with your eBay API credentials and other required information.
## Prerequisites
Before running the application, ensure that you have the following:

.NET Framework installed on your machine.
eBay developer account.
eBay API credentials (client ID and client secret).
## Configuration
The application requires certain configuration settings to be set in the app.config file. Update the following settings with your own values:

**TokenURL:** The URL for obtaining the access token.  
**ClientID:** Your eBay API client ID.  
**ClientSecret:** Your eBay API client secret.  
**SearchURL:** The URL for searching items on eBay.  
**affiliateCampaignId:** Your affiliate campaign ID.  
**affiliateReferenceId:** Your affiliate reference ID.  
**country:** The country to search for items (e.g., "US").  
**zip:** The ZIP code for the item location.  
**deviceId:** The ID of the device used for searching.  
## Functionality
The application provides the following functionality:

Searching for items on eBay based on user input.
Applying filters to the search query to refine the results. These filters can be modified in the MakeFilter method.
Pagination support to fetch all items matching the search criteria.
Displaying the search results in JSON format in the txtResult TextBox.
## Usage
Build and run the application.
Enter the search query in the txtQString TextBox.
Optionally, check the checkBox1 CheckBox to treat the search query as a single string.
Enter the limit and offset values for pagination in the txtLimit and txtOffset TextBoxes, respectively.
Click the "Search" button (btnSearch) to initiate the search.
The application will fetch the search results from the eBay API and display them in the txtResult TextBox.
Note: The application currently supports a maximum limit of 200 items per search due to API limitations.

## Additional Resources
For more information about the eBay API and available search filters, refer to the eBay Developer documentation:

## eBay API Documentation
eBay Browse API - Search Filters

## License
This project is licensed under the **Proprietary** license.

## Contact
For any inquiries or further information, please reach out to **Muneeb Ur Rehman** at muneeb110@live.com
