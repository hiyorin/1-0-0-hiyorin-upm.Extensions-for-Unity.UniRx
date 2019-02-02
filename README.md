# upm.Extensions-for-Unity.UniRx
package manager

# Requirement
* [UniRx](https://github.com/neuecc/UniRx)(6.1.1 or higher)
* [upm.Extensions-for-Unity](https://github.com/hiyorin/upm.Extensions-for-Unity.DOTween)


# Install
Specify repository URL git://github.com/hiyorin/upm.Extensions-for-Unity.git with key com.hiyorin.extensions into Packages/manifest.json like below.
```javascript
{
  "dependencies": {
    // ...
    "com.hiyorin.extensions": "git://github.com/hiyorin/upm.Extensions-for-Unity.git",
    "com.hiyorin.extensions.unirx": "git://github.com/hiyorin/upm.Extensions-for-Unity.UniRx.git",
    // ...
  }
}
```

# Usage
```cs
using UnityExtensions;
```
