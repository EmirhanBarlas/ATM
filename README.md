# ATM System

This is a simple ATM (Automated Teller Machine) system implemented in C#.

## Features

- User authentication with username and PIN
- Withdrawal of funds from user account
- Deposit of funds into user account
- Account locking after multiple failed login attempts
- User account data stored in a text file (`userdata.txt`)

## Getting Started

1. Clone this repository to your local machine.
2. Open the solution file (`ATM.sln`) in Visual Studio.
3. Build the solution to compile the code.
4. Run the application from Visual Studio or by executing the generated executable.

## Usage

1. When prompted, enter your username and PIN.
2. If authentication is successful, you will be presented with the main menu.
3. Choose an option from the menu to perform the desired transaction:
   - Enter `1` to withdraw funds
   - Enter `2` to deposit funds
4. Follow the instructions on the screen to complete the transaction.
5. After each transaction, your updated account balance will be displayed.

## User Data

User account data is stored in the `userdata.txt` file. Each line in the file represents a user account in the format:
- `username`: The username of the user
- `pin`: The PIN associated with the user's account
- `balance`: The current balance of the user's account
