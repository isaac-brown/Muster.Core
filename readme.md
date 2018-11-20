# Blog Core Package

This holds the core entities of the Blog domain.

## Top-level folder structure

This is the top-level folder structure. Inspired by [Ode to Code Folder Structure](https://odetocode.com/blogs/scott/archive/2018/10/17/net-core-opinion-5-deployment-scripts-and-templates.aspx) (.Net Core Opinion #5, #3 and #1).

``` cmd
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