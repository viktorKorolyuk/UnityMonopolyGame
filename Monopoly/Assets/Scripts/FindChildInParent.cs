using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindChildInParent {
  /*
   * Simple index search to find desired child in a parent object.
   * Search alrorithm simply reads through all children via the Transform property in parent.
   * If multiple GameObjects with same name are existant, code will return first avaliable.
   */

  //TODO: If "directory" already indexed, don't look through all other children again.
 // static List<Transform> index = new List<Transform>();
  public static GameObject findChild(Transform parent, string name) {
    //Loop through each transform element in the parent transform.
    foreach (Transform child in parent) {
      if (child.name == name) return child.gameObject; // "Hi, I would like to return this child.... what? Of course i'm serious! Stop looking at me like that!"
     
      // Search in sub-children (children in children)
      GameObject innerChild = findChild(child, name);
      if (innerChild != null) return innerChild;
    }
    return null;
  }

  //Optional way of doing same code
  public static GameObject findChild(GameObject parent, string name) {
    //Loop through each transform element in the parent transform.
    foreach (Transform child in parent.transform) {
      if (child.name == name) return child.gameObject;

      // Search in sub-children (children in children)
      GameObject innerChild = findChild(child, name);
      if (innerChild != null) return innerChild;
    }
    return null;
  }
}
