public interface D540OpeCodeVisitor
{
	virtual void caseOpeCode(D540OpeCode node);

	virtual void caseOpeNop(D540OpeNop node);

	virtual void caseOpeExecBlock(D540OpeExecBlock node);

	virtual void caseOpeCompound(D540OpeCompound node);

	virtual void caseOpeEcho(D540OpeEcho node);

	virtual void caseOpeSelf(D540OpeSelf node);

	virtual void caseOpePrint(D540OpePrint node);

	virtual void caseOpeSlicing(D540OpeSlicing node);

	virtual void caseOpeBinary(D540OpeBinary node);

	virtual void caseOpeUnary(D540OpeUnary node);

	virtual void caseOpeDup(D540OpeDup node);

	virtual void caseOpePrefab(D540OpePrefab node);

	virtual void caseOpeIfElse(D540OpeIfElse node);

	virtual void caseOpeInvokeMethod(D540OpeInvokeMethod node);

	virtual void caseOpeInvokeExtMethod(D540OpeInvokeExtMethod node);

	virtual void caseOpeArrayLiteral(D540OpeArrayLiteral node);

	virtual void caseOpePropertyValue(D540OpePropertyValue node);

	virtual void caseOpeField(D540OpeField node);

	virtual void caseOpeExtField(D540OpeExtField node);

	virtual void caseOpeAssignExtField(D540OpeAssignExtField node);

	virtual void caseOpeCast(D540OpeCast node);

	virtual void caseOpeExprStatement(D540OpeExprStatement node);

	virtual void caseOpeWhile(D540OpeWhile node);

	virtual void caseOpeDeclVar(D540OpeDeclVar node);

	virtual void caseOpeAssign(D540OpeAssign node);

	virtual void caseOpeLocalVar(D540OpeLocalVar node);

	virtual void caseOpeBuiltinFunc(D540OpeBuiltinFunc node);

	virtual void caseOpeMotionID(D540OpeMotionID node);

	virtual void caseOpeEnumOrString(D540OpeEnumOrString node);

	virtual void caseOpeValue(D540OpeValue node);

	virtual void caseOpeValueInt(D540OpeValueInt node);

	virtual void caseOpeValueObject(D540OpeValueObject node);

	virtual void caseOpeValueSingle(D540OpeValueSingle node);

	virtual void caseOpeValueString(D540OpeValueString node);

	virtual void caseOpeValueVector2(D540OpeValueVector2 node);

	virtual void caseOpeValueVector3(D540OpeValueVector3 node);

	virtual void caseOpeValueBool(D540OpeValueBool node);

	virtual void caseOpeAssert(D540OpeAssert node);
}
