# Blog Core Package

This holds the core entities of the Blog domain.

## Top-level folder structure

This is the top-level folder structure. Inspired by [Ode to Code Folder Structure](https://odetocode.com/blogs/scott/archive/2018/10/17/net-core-opinion-5-deployment-scripts-and-templates.aspx) (.Net Core Opinion #5, #3 and #1).

```cmd
┬╴ build
├╴ deploy
├╴ docs
├╴ samples
├╴ src
└╴ test
```

- `build`: Contains scripts to build this package.
- `deploy`: Contains scripts and files used to deploy this package.
- `docs`: Contains files that explain how to do things (build, run, test, deploy). Also any design collateral that might be of import (diagrams etc).
- `samples`: Samples that explain how to use the public API of this package.
- `src`: Source files for this package.
- `test`: Tests for this package.

> Note: Each folder has a `readme.md` file that tells you more about that folder, it's contents and how to use it.

## Building Muster.Core

To build this package run the following command:

```bash
# Build the library.
npm run build
```

## Running Muster.Core Unit Tests

To run the unit tests for this package a single time:

```bash
# Run unit tests once
npm test
```

Or to watch for changes and re-run tests automatically:

```bash
# Run unit tests each time a change is made.
npm run test:watch
```

## Releasing Muster.Core

Releasing can be done in one of the following ways:

| #   | Release type                        | Command                   |
| --- | ----------------------------------- | ------------------------- |
| 1   | [Cut a release](#cut-a-release)     | `npm run release`         |
| 2   | [Preview release](#preview-version) | `npm run release:preview` |
| 3   | [Dry release](#dry-release)         | `npm run release:dry`     |

### Cut a Release

To perform a release, run the following:

```bash
npm run release
```

This will do the following:

- Bump version in `package.json`, `package-lock.json` and `src/Muster.Core/Muster.Core.csproj`
- Write changes to `CHANGELOG`
- Commit all staged changes
- Tag release in git

### Preview Release

A preview version is supposed to be created when changes have been made, but a full release build isn't required just yet. This is basically a beta.

> Note that preview builds do not generate git tags, nor do they amend the `CHANGELOG` of the project, they just modify the version.

If you want to create a preview version, just run:

```bash
# Create preview version.
npm run release:preview
```

For example, if the current version is `1.1.0` and you have the following commit history:

```bash
* feat: another really neat feature
|
* chore(release): 1.1.0
|
* feat: something really neat
¦
```

Then if you run:

```bash
npm run release:preview
```

The git graph will then become:

```bash
* chore(release): 1.2.0.preview.0
|
* feat: another really neat feature
|
* chore(release): 1.1.0
|
* feat: something really neat
¦
```

And `package.json`, `package-lock.json` and `src/Muster.Core/Muster.Core.csproj` should now have a `version` of `1.2.0.preview.0`.

### Dry Release

To perform a dry run of the release (which might be useful to see what's going to happen), run the following:

```bash
npm run release:dry
```

This will just print output of what would happen if a release was cut. There are no side effects.
