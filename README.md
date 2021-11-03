# Frends.Community.CreateSignatureHash

FRENDS Task to create signature hash from hashed data. Supports MD5, SHA1, SHA 256, SHA 384 and SHA 512 hash algorithms.

[![Actions Status](https://github.com/CommunityHiQ/Frends.Community.CreateSignatureHash/workflows/PackAndPushAfterMerge/badge.svg)](https://github.com/CommunityHiQ/Frends.Community.CreateSignatureHash/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Community.CreateSignatureHash) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [CreateSignatureHash](#CreateSignatureHash)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the task via FRENDS UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Community.CreateSignatureHash

# Tasks

## CreateSignatureHash
FRENDS Task to create signature hash from hashed data. Supports MD5, SHA1, SHA 256, SHA 384 and SHA 512 hash algorithms.

### Input

| Property				|  Type   | Description								| Example                     |
|-----------------------|---------|-----------------------------------------|-----------------------------|
| HashedData		| string	| Hashed data | ´0a50261ebd1a390fed2bf326f2673c145582a6342d523204973d0219337f81616a8069b012587cf5635f6925f1b56c360230c19b273500ee013e030601bf2425´ |
| PrivateKey		| string	| RSA private key in xml format	| https://msdn.microsoft.com/en-us/library/system.security.cryptography.rsa.toxmlstring(v=vs.110).aspx |
| HashFunction	| enum	| Supported hash types	| ´SHA512´ |

### Output

| Property      | Type     | Description                     |
|---------------|----------|---------------------------------|
| Hash        | string   | Signature hash |

Usage:
To fetch result use syntax:

`#result.Hash`

# Building

Clone a copy of the repo

`git clone https://github.com/CommunityHiQ/Frends.Community.CreateSignatureHash.git`

Rebuild the project

`dotnet build`

Run Tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 1.0.0   | Initial version |
| 1.1.0   | Multi-framework and Github actions support  |
