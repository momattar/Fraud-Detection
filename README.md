# 🛡️ Fraud Detection Web App (ASP.NET MVC)

This is a web application built with ASP.NET MVC that helps detect fraudulent transactions and loan applications using trained machine learning models served through Flask APIs.

---

## 📌 Overview

The project consists of two main fraud detection modules:

1. **Transactions Fraud Detection**  
   Uses user-inputted transaction data to detect fraud.

2. **Loans Fraud Detection**  
   Uses loan application details to predict fraudulent applications.

These models are hosted via Flask APIs, and this MVC app sends user data to those APIs and displays the prediction results in a clean UI.

---

## 🌐 Hosted Flask APIs

- 🔄 **Transactions API:**  
  GitHub Repo: [transactionsMLapi](https://github.com/momattar/transactionsMLapi)

- 💸 **Loans API:**  
  GitHub Repo: [LoansMLapi](https://github.com/momattar/LoansMLapi)

Each API exposes a `/predict` endpoint that receives a JSON object with input data and returns a JSON response with a binary prediction:
```json
{ "prediction": 0 }  // Not Fraud
{ "prediction": 1 }  // Fraud
