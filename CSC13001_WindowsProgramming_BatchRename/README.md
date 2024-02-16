# Project Batch Rename

## 📢Introduction

Batch Rename Application is the first project in Windows Programming.

Application provides many functions to rename multiple files and folders.

## 👩‍👧‍👦 Members in the team

| Student's ID | Full name |
| ----------- | ------------- |
| 19120302 | Đoàn Thu Ngân |
| 19120426 | Phan Đặng Diễm Uyên |
| 19120433 | Lưu Đức Vũ |

## ‼ Compile and run the project

If the .exe file in the release folder is not working, please do following these steps:
- Open **Source code** folder
- Open **Batch Rename** folder
- Open **Batch Rename.sln**
- Choose **Batch Rename** project
- Run without debugging in **Release** mode

## 🔑 Core Requirements

- [x] **1. Dynamically load all renaming rules from external DLL files**
  - [x] a. Change the extension to another extension
  - [x] b. Add counter to the end of the file
  - [x] c. Remove all space from the beginning and the ending of the filename
  - [x] d. Replace certain characters into one character like replacing "-" ad "_" into space " "
  - [x] e. Adding a prefix to all the files
  - [x] f. Adding a suffix to all the files
  - [x] g. Convert all characters to lowercase, remove all spaces
  - [x] h. Convert filename to PascalCase
- [x] **2. Select all files and folders you want to rename**
- [x] **3. Create a set of rules for renaming the files**
  - [x] a. Each rule can be added from a menu
  - [x] b. Each rule's parameters can be edited
- [x] **4. Apply the set of rules in numerical order to each file, make them have a new name**
- [x] **5. Save this set of rules into presets for quickly loading later if you need to reuse**

## 💯 Improvements

- [x] 1. Drag and Drop a file to add to the list
- [x] 2. Storing parameters for renaming using XML file / JSON / excel / database
- [x] 3. Adding recursively: just specify a folder only, the application will automatically scan and add all the files inside
- [ ] 4. Handling duplication
- [ ] 5. Last time state: When exiting the application, auto-save and load the
  - [ ] a. The current size of the screen
  - [x] b. Current position of the screen
  - [ ] c. Last chosen preset
- [ ] 6. Autosave & load the current working condition to prevent sudden power loss
  - [ ] a. The current file list
  - [ ] b. The current set of renaming rules, together with the parameters
- [x] 7. Using regular expression
- [ ] 8. Checking exceptions when editing rules
  - [x] a. Characters that cannot be in the file name
  - [ ] b. The maximum length of the filename cannot exceed 255 characters
- [ ] 9. Save and load your work into a project
- [x] 10. Let the user see the preview of the result
- [x] 11. Create a copy of all the files and move them to a selected folder rather than perform the renaming on the original file

## 🕑 Hours to do

| Task name | Hours |
| ------------- | --- |
| Core Requirements - 1 | 20 |
| Core Requirements - 2 | 8 |
| Core Requirements - 3 | 6 |
| Core Requirements - 4 | 2 |
| Core Requirements - 5 | 14 |
| Improvements - 1 | 3.5 |
| Improvements - 2 | 5 |
| Improvements - 3 | 5.5 |
| Improvements - 5b | 2 |
| Improvements - 7 | 4.5 |
| Improvements - 8a | 5 |
| Improvements - 10 | 8 |
| Improvements - 11 | 6 |
| **SUM** | **89.5** |

## 📌 Expected grade

| Student's ID | Fullname | Grade |
| -------- | -------------------| --- |
| 19120302 | Đoàn Thu Ngân | 10 |
| 19120426 | Phan Đặng Diễm Uyên | 10 |
| 19120433 | Lưu Đức Vũ | 10 |

## 📽 Video demo
URL: [Project Batch Rename Demo](https://www.youtube.com/watch?v=rccXvDtXC_k)
