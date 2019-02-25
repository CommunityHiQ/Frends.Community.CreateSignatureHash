**[Table of Contents](http://tableofcontent.eu)**
- [Frends.Community.CreateSignatureHash](#frendscommunitycreatesignaturehash)
  - [Contributing](#contributing)
  - [Documentation](#documentation)
    - [Input](#input)
    - [Output](#output)
  - [License](#license)


# Frends.Community.CreateSignatureHash
FRENDS Task to create signature hash from hashed data. Supports MD5, SHA1, SHA 256, SHA 384 and SHA 512 hash algorithms.

## Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repo on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

## Documentation

### Input

| Property				|  Type   | Description								| Example                     |
|-----------------------|---------|-----------------------------------------|-----------------------------|
| HashedData		| string	| Hashed data | ´0a50261ebd1a390fed2bf326f2673c145582a6342d523204973d0219337f81616a8069b012587cf5635f6925f1b56c360230c19b273500ee013e030601bf2425´ |
| PrivateKey		| string	| RSA private key in xml format	| https://msdn.microsoft.com/en-us/library/system.security.cryptography.rsa.toxmlstring(v=vs.110).aspx |
| HashFunction	| enum	| Supported hash types	| ´SHA512´ |

### Output

| Property      | Type     | Description                      |
|---------------|----------|----------------------------------|
| Hash        | string   | Signature hash |

## License

This project is licensed under the MIT License - see the LICENSE file for details
