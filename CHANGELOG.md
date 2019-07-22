# Changelog

All notable changes to this project will be documented in this file. See [standard-version](https://github.com/conventional-changelog/standard-version) for commit guidelines.

## [0.2.0](https://github.com/isaac-brown/Muster.Core/compare/v0.1.2...v0.2.0) (2019-07-22)


### Bug Fixes

* **blog-post:** remove `private` setter on `Content` ([327ca02](https://github.com/isaac-brown/Muster.Core/commit/327ca02))


### Features

* **blog-post:** change `Id` to string type ([67a4eca](https://github.com/isaac-brown/Muster.Core/commit/67a4eca))
* **pagination:** rewrite pagination so there is no `Navigation` ([ebb4f6c](https://github.com/isaac-brown/Muster.Core/commit/ebb4f6c))
* **repository:** add `IAsyncRepsitory` interface ([bf4cf87](https://github.com/isaac-brown/Muster.Core/commit/bf4cf87))
* **tag:** is now a `struct` rather than a class ([40b62d7](https://github.com/isaac-brown/Muster.Core/commit/40b62d7))
* **tag:** rename `Create` method to `FromName` ([e59fbb7](https://github.com/isaac-brown/Muster.Core/commit/e59fbb7))


### BREAKING CHANGES

* **blog-post:** no longer a Guid



### [0.1.2](https://github.com/isaac-brown/Muster.Core/compare/v0.1.1...v0.1.2) (2019-07-14)


### Bug Fixes

* **blog-post:** swapped over to use dedicated builder class ([ab0a76a](https://github.com/isaac-brown/Muster.Core/commit/ab0a76a))
* **tag:** remove property `Id` ([e51fcc8](https://github.com/isaac-brown/Muster.Core/commit/e51fcc8))



### [0.1.1](https://github.com/isaac-brown/Muster.Core/compare/v0.1.0...v0.1.1) (2019-07-10)


### Bug Fixes

* **enumeration:** methods GetAll, FromKeyCode and FromDisplayName now actually work ([fbd89ad](https://github.com/isaac-brown/Muster.Core/commit/fbd89ad))



## 0.1.0 (2019-06-29)

### Features

- add repository interfaces ([148f1e1](https://github.com/isaac-brown/Muster.Core/commit/148f1e1))
- implement `PagedEnumerable` ([79c9030](https://github.com/isaac-brown/Muster.Core/commit/79c9030))
- implement `PagedEnumerableCount` ([69af09d](https://github.com/isaac-brown/Muster.Core/commit/69af09d))
- implement `PagedEnumerableMetadata` ([de18409](https://github.com/isaac-brown/Muster.Core/commit/de18409))
- implement `PagedEnumerableNavigation` ([590c744](https://github.com/isaac-brown/Muster.Core/commit/590c744))

### 0.0.2 (2019-02-10)

#### Features

- Initial implementation of a `BlogPost`. This has some content, a status (`Draft` or `Published`) and a set of associated tags.
- Initial implementation of a `Tag`. This has a non-empty name.

### 0.0.1 (2019-02-05)

#### Features

- Initial project structure (top level folders).
- Initial source project with dependencies.
- Initial test project with dependencies.
- MIT licence for project.
- Readme for project.
- Changelog for project.
- Icon for project.
