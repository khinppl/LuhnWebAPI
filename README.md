# LuhnWebAPI
This API validates credit card numbers using the Luhn algorithm.

**Endpoints**

Validate Credit Card

**GET** /api/CreditCard/validatecardnumber

**Validation Rules**
The cardNumber must be:

**> A numeric string.**
    15 or 16 digits long.
    Invalid input will return a 400 Bad Request with an appropriate error message.
    
**> Query Parameters**
    cardNumber (string, required): The credit card number to validate.
**Example Request**
    "http://localhost:5000/api/CreditCard/validatecardnumber?cardNumber=4532015112830366"

**Response**

Success: 200 with Validation result Error: 400 Bad Request

